using GSGD1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerLauncher : AWeapon
{
    [SerializeField]
    private int _damage = 1;

    //[SerializeField]
    //private FlameThrowerProjectile _projectile = null;

    [SerializeField]
    private ParticleSystem _flameParticule;

    [SerializeField]
    private Transform _projectileAnchor = null;

    [SerializeField]
    private DamageableDetector _damageableDetector;

    protected override void DoFire()
    {
        if (_damageableDetector.HasAnyDamageableInRange() == true)
        {
            List<Damageable> damageables = _damageableDetector.GetDamageablesInRange();
            for (int i = 0; i < damageables.Count; i++)
            {
                damageables[i].TakeDamage(_damage);
                
            }
        }

        Instantiate(_flameParticule, _projectileAnchor.position, _projectileAnchor.rotation);
        Debug.Log("Tiiire");
    }


}

