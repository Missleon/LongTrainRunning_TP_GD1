using GSGD1;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SetPath : MonoBehaviour
{

    [SerializeField]
    private Path _path = null;

    private Camera _camera = null;

    [SerializeField]
    private LayerMask _layerToHit;

    private Vector3 _screenPosition;

    private void OnEnable()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<Transform> waypointsList = _path.Waypoints;
            //waypointsList[waypointsList.Count + 1].position = PlaceWaypoint()
        }

    }

    private Vector3 PlaceWaypoint(Vector3 position)
    {

        _screenPosition = Input.mousePosition;

        Ray ray = _camera.ScreenPointToRay(_screenPosition);

        RaycastHit hitdata;

        if (Physics.Raycast(ray, out hitdata))
        {

            position = hitdata.point;

        }
        return position;

    }

}
