using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Player : Health
{
    public GameObject panel;
    private void Start()
    {
        StartCoroutine(LateInit());
        
    }
    public override void OnDeath()
    {
        base.OnDeath();
        gameObject.SetActive(false);
        Time.timeScale = 0;
        panel.SetActive(true);

    }

    IEnumerator LateInit()
    {
        yield return new WaitForSeconds(0.5f);
        character.Initialize(Stats.instance.playerHP, Stats.instance.playerDFactor, character.movementSpeed, character.attackRange, character.sightRange);
        currentHealth = charHealth;
        healthBar.SetMaxHealth(charHealth);
    }

}
