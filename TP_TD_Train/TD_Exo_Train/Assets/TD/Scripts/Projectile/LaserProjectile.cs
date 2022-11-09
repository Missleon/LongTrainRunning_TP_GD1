using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1f;

    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private float _damageRate = 0.3f;

    private float _currentTime = 0f;

    private void Update()
    {
        MoveForward();

    }

    private void MoveForward()
    {
        transform.position = transform.position + _moveSpeed * Time.deltaTime * transform.forward;
    }

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
