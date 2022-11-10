using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;

public class UITextManager : MonoBehaviour
{


    [SerializeField]
    private int _currentGoldNmb = 0;

    [SerializeField]
    private TextMeshProUGUI _currentGoldNmbText = null;

    [SerializeField]
    private int _currentWaveNmb = 0;

    [SerializeField]
    private TextMeshProUGUI _currentWaveNmbText = null;

    [SerializeField]
    private int _nmbEnemyWave = 0;

    [SerializeField]
    private TextMeshProUGUI _nmbEnemyWaveText = null;

    [SerializeField]
    private int _currentEnemyKilled = 0;

    [SerializeField]
    private TextMeshProUGUI _currentEnemyKilledText = null;




    private void Update()
    {
        _currentGoldNmbText.SetText("" + _currentGoldNmb);
        _currentWaveNmbText.SetText("" + _currentWaveNmb + "/5");
        _nmbEnemyWaveText.SetText("/ " + _nmbEnemyWave);
        _currentEnemyKilledText.SetText("" + _currentEnemyKilled);
    }


}
