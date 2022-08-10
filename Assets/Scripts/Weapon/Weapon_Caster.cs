using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Caster : Weapon
{
    public override void Attack()
    {
        Projectile circle = Instantiate(projectile);
        circle.Initialize(enemy, damageFactor, this);
        circle.transform.position = character.FindClosestEnemy(transform.position , range).transform.position+new Vector3(0,0.1f,0);
    }
}
