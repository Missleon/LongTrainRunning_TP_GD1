using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEnnemie : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private int _goldRequin = 50;

    [SerializeField]
    private int _goldPoissonGlobe = 35;

    [SerializeField]
    private int _goldAnguille = 25;


    [SerializeField]
    private bool _anguille;

    [SerializeField]
    private bool _requin;

    [SerializeField]
    private bool _poissonGlobe;

    

    public void GoldOnDeath ()
    {
        GoldGestion goldGestion = LevelReferences.Instance.GoldGestion;

        if (_requin == true)
        {
            goldGestion._gold = goldGestion._gold + _goldRequin;
        }

        if (_anguille == true)
        {
            goldGestion._gold = goldGestion._gold + _goldAnguille;
        }

        if (_poissonGlobe == true)
        {
            goldGestion._gold = goldGestion._gold + _goldPoissonGlobe;
        }
    }
}
