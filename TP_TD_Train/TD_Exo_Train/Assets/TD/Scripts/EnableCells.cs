using GSGD1;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private List<Cell> _cellsInRange = new List<Cell>();

    private void OnTriggerEnter(Collider other)
    {
        Cell cell = other.GetComponent<Cell>();

        if (other.gameObject != null && other.gameObject == cell)
        {
            other.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Cell cell = other.GetComponent<Cell>();

        if (other.gameObject != null && other.gameObject == cell)
        {
            other.gameObject.SetActive(false);
        }
    }
    

}
