using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float cameraShakeIntensity = .75f;
    float cameraShakeTime=.05f;
    public int damage;
    float damageFactor;
    public GameObject model;
    public Weapon weapon;
    public LayerMask enemy;
    private Health hitCharacter;
    public float lifetime;
    
    private void Start()
    {
        CinemachineShake.Instance.ShakeCamera(cameraShakeIntensity, cameraShakeTime);
        Destroy(gameObject, lifetime);
    }

    public void OnTriggerEnter(Collider other)
    {     
        //Debug.Log("Collider layer = " + other.gameObject.layer + "Enemy layer = " + enemy);
        if (enemy == (enemy | (1 << other.gameObject.layer)))
        {
            OnHit(other.GetComponent<Health>());
        }   
    }

    public virtual void OnHit(Health health)
    {
        health.GetDamage(damage * damageFactor);
        model.SetActive(false);
        Destroy(gameObject,.2f);
    } 

    public void Initialize(LayerMask enemy, float damageFactor, Weapon weapon)
    {
        this.weapon = weapon;
        this.enemy = enemy;
        this.damageFactor = damageFactor;
    }
    //timer yaz !
}
