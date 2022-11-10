using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGestion : MonoBehaviour
{
    [SerializeField]
    public int _gold = 0;

    [SerializeField]
    private int _goldPerTime = 2;

    [SerializeField]
    private float _time = 0f;

    private float _lastTime = 0f;  

    private void Update()
    {
        _lastTime += Time.fixedDeltaTime;  	
        if (_lastTime > _time)
        {
            GetGold();
            _lastTime = 0;
        }
    }

    private void GetGold()
    {
        _gold = _gold + _goldPerTime;
    }
}
