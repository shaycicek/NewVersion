using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float range;
    public float AttackRate;
    public Projectile projectile;
    public Character character;
    protected LayerMask enemy;
    public float damageFactor;
    public Transform bulletHole;
    public virtual void InitializeWeapon(Character owner, LayerMask enemy , float damageFactor)
    {
        character = owner;
        this.enemy = enemy;
        this.damageFactor = damageFactor;
    }

    public virtual void Attack()
    {
        Projectile proj = Instantiate(projectile);
        proj.Initialize(enemy, damageFactor, this);
        //gameObject.transform.LookAt(character.FindClosestEnemy(character.transform.position, 50)); // KALDIR!
        proj.transform.position = bulletHole.position;
    }
}
