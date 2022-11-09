using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : AProjectile
{
    [SerializeField]
    private AExplosion _myExplosion = null;

    [SerializeField]
    private float _moveSpeed = 1f;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position = transform.position + _moveSpeed * Time.deltaTime * transform.forward;
    }
    protected override void BeforeDestroy()
    {
       GameObject myExplosion = _myExplosion.GetExplosion();

        Instantiate(myExplosion, transform.position, transform.rotation);

        Debug.Log(myExplosion);
    }

    

}
