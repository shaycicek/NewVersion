using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Whirlwind : Skill
{
    
    float timer=0;
    float radius;
    float damage;
    public Skill_Whirlwind(GameObject particle , float radius , float damage , SkillUseTypes skillUse , float energyTimer , int cost) : base(skillUse , cost)
    {
        particleEffect = particle;
        this.radius = radius;
        this.damage = damage;
        this.energyTimer = energyTimer;
    }

    public override void UseSkill()
    {
        //player damage 
        timer += Time.deltaTime;
        character.currentDefenceRate = character.defenceRate + character.defenceRate / 2;
        if (timer > 0.3f)
        {
            Collider[] hitColliders = Physics.OverlapSphere(character.transform.position, radius, character.enemy);
            foreach (var hitCollider in hitColliders)
            {
                if (!hitCollider.gameObject.GetComponent<Character>().isDead)
                {
                    hitCollider.gameObject.GetComponent<Health>().GetDamage(damage);
                    //hitCollider.gameObject.GetComponent<Animator>().SetTrigger("isKnocked");  ÝHTÝMALLÝ KNOCKBACK OLabilir
                }
            }
            timer = 0;
        }

    }

    public override void FinishSkill()
    {
        character.currentDefenceRate = character.defenceRate;
    }
}
