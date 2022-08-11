using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Melee : Weapon
{
    public int damage;

    public override void Attack()
    {
        Debug.Log(character.FindClosestEnemy(transform.position, range));
        character.FindClosestEnemy(transform.position, range).gameObject.GetComponent<Health>().GetDamage(damage * damageFactor);
    }
}
