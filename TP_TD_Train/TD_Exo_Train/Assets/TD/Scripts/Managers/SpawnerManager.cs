namespace GSGD1
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public enum SpawnerIndex
    {
        Spawner00,
        Spawner01,
        Spawner02,
    }

    public enum SpawnerStatus
    {
        Inactive = 0,
        WaveRunning
    }

    public class SpawnerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _spawner1;

        [SerializeField]
        private GameObject _spawner2;

        [SerializeField]
        private GameObject _spawner3;

        [SerializeField]
        private GameObject _spawner4;

        [SerializeField]
        private GameObject _spawner5;

        [SerializeField]
        private GameObject _spawner6;

        [SerializeField]
        private GameObject _spawner7;


        private int _nombreDeWave = 0;

        [SerializeField]
        private GameObject _phaseJoueur;

        [SerializeField]
        private GameObject _phaseEnnemie;

        [SerializeField]
        private float _timePhase1 = 30f;




        [SerializeField]
        private List<EntitySpawner> _spawners = null;

        [SerializeField]
        private bool _autoStartNextWaves = false;

        [System.NonSerialized]
        private int _currentWaveSetIndex = -1;

        [System.NonSerialized]
        private int _currentWaveRunning = 0;

        [SerializeField]
        public UnityEvent<SpawnerManager, SpawnerStatus, int> WaveStatusChanged_UnityEvent = null;

        public delegate void SpawnerEvent(SpawnerManager sender, SpawnerStatus status, int runningWaveCount);
        public event SpawnerEvent WaveStatusChanged = null;

        [ContextMenu("Start waves")]
        public void StartWaves()
        {
            // Start a new wave set only if there are no currently a wave running
            if (_currentWaveRunning <= 0)
            {
                StartNewWaveSet();

            }
        }

        public void StartNewWaveSet()
        {
            if (_phaseEnnemie == true)
            {
                _phaseEnnemie.SetActive(false);

                if (_nombreDeWave == 0)
                {
                    _spawner1.SetActive(false);
                    _spawner2.SetActive(true);
                    _spawner3.SetActive(false);
                    _spawner4.SetActive(false);
                    _spawner5.SetActive(false);
                    _spawner6.SetActive(false);
                    _spawner7.SetActive(false);
                    _nombreDeWave++;
                }

                if (_nombreDeWave == 1)
                {
                    _spawner1.SetActive(false);
                    _spawner2.SetActive(false);
                    _spawner3.SetActive(false);
                    _spawner4.SetActive(true);
                    _spawner5.SetActive(false);
                    _spawner6.SetActive(true);
                    _spawner7.SetActive(false);
                    _nombreDeWave++;
                }

                if (_nombreDeWave == 2)
                {
                    _spawner1.SetActive(true);
                    _spawner2.SetActive(false);
                    _spawner3.SetActive(true);
                    _spawner4.SetActive(false);
                    _spawner5.SetActive(false);
                    _spawner6.SetActive(false);
                    _spawner7.SetActive(true);
                    _nombreDeWave++;
                }

                if (_nombreDeWave == 3)
                {
                    _spawner1.SetActive(true);
                    _spawner2.SetActive(true);
                    _spawner3.SetActive(false);
                    _spawner4.SetActive(true);
                    _spawner5.SetActive(true);
                    _spawner6.SetActive(false);
                    _spawner7.SetActive(false);
                    _nombreDeWave++;
                }

                if (_nombreDeWave == 4)
                {
                    _spawner1.SetActive(true);
                    _spawner2.SetActive(false);
                    _spawner3.SetActive(true);
                    _spawner4.SetActive(false);
                    _spawner5.SetActive(true);
                    _spawner6.SetActive(true);
                    _spawner7.SetActive(true);
                    _nombreDeWave++;
                }

                _currentWaveSetIndex += 1;
                var waveDatabase = DatabaseManager.Instance.WaveDatabase;

                if (waveDatabase.Waves.Count > _currentWaveSetIndex)
                {
                    WaveSet waveSet = waveDatabase.Waves[_currentWaveSetIndex];
                    List<Wave> waves = waveSet.Waves;

                    for (int i = 0, length = _spawners.Count; i < length; i++)
                    {
                        if (i >= waves.Count)
                        {
                            Debug.LogWarningFormat("{0}.StartNewWaveSet() There are more spawner ({1}) than wave ({2}), discarding wave.", GetType().Name, _spawners.Count, waves.Count);
                            break;
                        }
                        if (waves[i] == null)
                        {
                            Debug.LogWarningFormat("{0}.StartNewWaveSet() Null reference found in WaveSet at index {1}, ignoring.", GetType().Name, i);
                            break;
                        }
                        _currentWaveRunning += 1;
                        var spawner = _spawners[i];
                        spawner.StartWave(waves[i]);
                        spawner.WaveEnded.RemoveListener(Spawner_OnWaveEnded);
                        spawner.WaveEnded.AddListener(Spawner_OnWaveEnded);

                        WaveStatusChanged?.Invoke(this, SpawnerStatus.WaveRunning, _currentWaveRunning);
                        WaveStatusChanged_UnityEvent?.Invoke(this, SpawnerStatus.WaveRunning, _currentWaveRunning);

                        StartCoroutine(Phase1());

                    }
                }
                else
                {
                    // No waves left : end game

                }



            }



        }

        IEnumerator Phase1()
        {
            yield return new WaitForSeconds(_timePhase1);
            _phaseJoueur.SetActive(true);

        }



        private void Spawner_OnWaveEnded(EntitySpawner entitySpawner, Wave wave)
        {
            entitySpawner.WaveEnded.RemoveListener(Spawner_OnWaveEnded);

            _currentWaveRunning -= 1;

            WaveStatusChanged?.Invoke(this, SpawnerStatus.Inactive, _currentWaveRunning);
            WaveStatusChanged_UnityEvent?.Invoke(this, SpawnerStatus.Inactive, _currentWaveRunning);

            // should we run a new wave?
            if (_autoStartNextWaves == true && _currentWaveRunning <= 0)
            {
                StartNewWaveSet();
            }
        }
    }
}