﻿namespace GSGD1
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
        private List<Transform> _waypoints = null;

        [SerializeField]
        private bool _showGizmos = true;

        [SerializeField]
        private Color _lineColor = Color.white;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private GameObject _player = null;

        private readonly Vector3 _offset = new Vector3(0, 0.5f, 0);


        public void SetWaypoint(Transform waypointTransform)
        {
            if (_waypoints.Count == 0)
            {
                _waypoints.Add(_player.transform);
            }

            Transform lastWaypoint = _waypoints[_waypoints.Count - 1];

            Vector3 rayDirection = waypointTransform.position - lastWaypoint.position;

            Debug.Log(rayDirection);

            if (Physics.Raycast(waypointTransform.position, rayDirection, rayDirection.magnitude) == true)
            {
                _waypoints.Add(waypointTransform);
                Debug.Log("loel");
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