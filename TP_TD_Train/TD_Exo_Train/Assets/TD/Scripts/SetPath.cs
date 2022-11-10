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
    private GameObject _phaseEnnemie;

    [SerializeField]
    private GameObject _phaseJoueur;

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
    {   if(_phaseJoueur == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceWaypoint();
            }
        }
        
            
        
        
        

    }

    private void PlaceWaypoint()
    {

        _screenPosition = Input.mousePosition;

        Ray ray = _camera.ScreenPointToRay(_screenPosition);

        RaycastHit hitdata;

        if (Physics.Raycast(ray, out hitdata))
        { 

            GameObject go = new GameObject();

            go.transform.position = hitdata.point;

            _path.SetWaypoint(go.transform);

            

        }
        

    }

}
