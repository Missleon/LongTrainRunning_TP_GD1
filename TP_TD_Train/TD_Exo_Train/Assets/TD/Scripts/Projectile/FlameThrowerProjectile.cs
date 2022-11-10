using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerProjectile : MonoBehaviour
{
    [SerializeField]
    private Transform _projectileAnchor = null;

    

    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private float _damageRate = 0.3f;

    private float _currentTime = 0f;



    private void OnTriggerStay(Collider other)
    {
        var damageable = other.GetComponentInParent<Damageable>();

        if (damageable != null)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _damageRate)
            {
                damageable.TakeDamage(_damage);

                _currentTime = 0f;    
            }

        }
    }

}
