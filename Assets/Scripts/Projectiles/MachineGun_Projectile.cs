using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun_Projectile : Projectile
{
    public float speed;
    public ParticleSystem destroyingParticle;
    public ParticleSystem onFireParticle;

    private void Start()
    {
        ProjectileStart();
        onFireParticle.gameObject.SetActive(true);
        GetComponent<Rigidbody>().AddForce(-weapon.transform.forward * speed, ForceMode.Impulse);
    }

    public override void OnHit(Health health)
    {
        base.OnHit(health);
        onFireParticle.gameObject.SetActive(false);
        GameObject destroyingPart;
        destroyingPart = Instantiate(destroyingParticle, transform.position, Quaternion.identity).gameObject;
        destroyingPart.transform.LookAt(weapon?.transform);
        GetComponent<Collider>().enabled = false;
        Destroy(destroyingPart, .2f);
    }
}
