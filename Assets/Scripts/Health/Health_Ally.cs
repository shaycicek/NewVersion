using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Ally : Health
{
    string charType;
    private void Start()
    {                
        StartCoroutine(LateInit());
        
    }
    public override void OnDeath()
    {
        base.OnDeath();
        GetComponent<StateMachine>().enabled = false;
        Destroy(gameObject ,2f);
    }

    IEnumerator LateInit()
    {
        yield return new WaitForSeconds(0.5f);
        character.Initialize(Stats.instance.allyHP, Stats.instance.allyDamageFactor, character.movementSpeed, character.attackRange, character.sightRange);
        currentHealth = charHealth;
        healthBar.SetMaxHealth(charHealth);
    }
}
