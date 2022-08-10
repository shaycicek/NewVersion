using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_DamageMultiplier : Skill
{
    ParticleSystem particle;
    int multiplier;
    float skillTimer;
    GameObject skillParticle;

    public Skill_DamageMultiplier(SkillUseTypes skillUse, ParticleSystem particle , int multiplier , float skillTimer , int cost) : base(skillUse,cost)
    {
        this.particle = particle;
        this.multiplier = multiplier;
        this.skillTimer = skillTimer;
    }

    public override void FinishSkill()
    {
        GameObject.Destroy(skillParticle);
        character.damageFactor /= multiplier;
    }

    public override void UseSkill()
    {
        if(GameManager.instance.crystalCount >=UseCost)
        {
            skillParticle = GameObject.Instantiate(particle, new Vector3(character.transform.position.x, character.transform.position.y + 1.35f,
        character.transform.position.z), Quaternion.identity).gameObject;
            skillParticle.transform.parent = character.transform;
            skillParticle.transform.localScale = new Vector3(4, 4, 4);
            GameManager.instance.ChangeValueOfCrystal(-useCost);            
            character.GetComponent<SkillManager>().StartSkillCountdown(this, skillTimer);
            character.damageFactor *= multiplier;

        }

        //Süre dolunca resetlenecek ???
    }

}
