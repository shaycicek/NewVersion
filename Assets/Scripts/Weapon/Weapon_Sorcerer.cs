using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Sorcerer : Weapon
{
    public override void Attack()
    {
        Projectile proj = Instantiate(projectile);
        proj.Initialize(enemy, damageFactor, this);
        proj.transform.position = bulletHole.position;
        proj.GetComponent<Sorcerer_Proj>().EnemyPosInit(character.FindClosestEnemy(transform.position, range));


    }
}
