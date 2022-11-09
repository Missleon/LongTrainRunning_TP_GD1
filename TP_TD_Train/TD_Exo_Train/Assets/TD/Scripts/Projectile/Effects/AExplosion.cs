using GSGD1;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public abstract class AExplosion : MonoBehaviour
{
    [SerializeField]
    private float _destroyTime = 1f;

    [SerializeField]
    private int _damage = 1; 

    private float _currentTime = 0f;

    public GameObject GetExplosion()
    {
        return gameObject;
    }   
    
    public Vector3 GetExplosionRadius()
    {
        return this.gameObject.transform.localScale;
    }


    private void OnEnable()
    {
        Rigidbody rigidbody = GetComponentInParent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;

    }

    private void Update()
    {
        if (_currentTime >= _destroyTime)
        {
            Destroy(this.gameObject);
        }

        else
        {
            _currentTime += Time.deltaTime;
        }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponentInParent<Damageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
        }
    }

}
