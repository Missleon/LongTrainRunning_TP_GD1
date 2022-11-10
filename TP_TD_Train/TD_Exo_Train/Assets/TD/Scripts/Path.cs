namespace GSGD1
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif //UNITY_EDITOR

    public class Path : MonoBehaviour
    {
        [SerializeField]
        private GameObject _phaseJoueur;

        [SerializeField]
        private GameObject _phaseEnnemie;

        [SerializeField]
        private List<Transform> _waypoints = null;

        [SerializeField]
        private bool _showGizmos = true;

        [SerializeField]
        private Color _lineColor = Color.white;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private GameObject _player = null;

        [SerializeField]
        private int _waypointLimit = 6;

        private readonly Vector3 _offset = new Vector3(0, 0.5f, 0);


        public void SetWaypoint(Transform waypointTransform)
        {
            //if (_waypoints.Count <= 0)
            //{
            //    _waypoints.Add(_player.transform);
            //}

            //Transform lastWaypoint = _waypoints[_waypoints.Count - 1];

            //Vector3 rayDirection = waypointTransform.position - lastWaypoint.position;

            //Debug.DrawRay(waypointTransform.position, rayDirection, Color.red, 100, true);

            //if (Physics.Raycast(waypointTransform.position, rayDirection, rayDirection.magnitude - 0.5f) == true)
            //{

            //    Debug.Log("loel");
            //}

            if (_waypoints.Count >= 6)
            {
                _phaseJoueur.SetActive(false);
                _phaseEnnemie.SetActive(true);
            }
            else
            {

                _waypoints.Add(waypointTransform);
            }

        }


        public List<Transform> Waypoints
        {
            get
            {
                return _waypoints;
            }
        }

        public Transform FirstWaypoint
        {
            get
            {
                if (_waypoints != null && _waypoints.Count > 1)
                {
                    return _waypoints[0];
                }
                else
                {
                    return null;
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (_showGizmos == false || _waypoints == null)
            {
                return;
            }

            for (int i = 0, length = _waypoints.Count - 1; i < length; i++)
            {
                Transform currentWaypoint = _waypoints[i];
                Transform nextWaypoint = _waypoints[i + 1];
                if (currentWaypoint != null && nextWaypoint != null)
                {
                    Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
                    var color = Handles.color;
                    Handles.color = _lineColor;
                    {
                        Handles.DrawLine(currentWaypoint.position + _offset, nextWaypoint.position + _offset);
                    }
                    Handles.color = color;
                }
            }
        }
#endif //UNITY_EDITOR

    }
}