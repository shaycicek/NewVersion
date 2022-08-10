using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Skill_Dash : Skill
{   
    float skillTimer;
    //float dash    
    public Skill_Dash(SkillUseTypes skillUse , float cooldownTime , int cost) : base(skillUse ,cost)
    {
        this.skillTimer = cooldownTime;
    }

    public override void UseSkill()
    {
        //DASH MESAFESÝ BELÝRLE!!!
        //DASH DamageRate;
        character.GetComponent<PlayerController>().canMove = false;
        Sequence dashAnim;
        dashAnim = DOTween.Sequence();
        dashAnim.Append(character.GetComponent<Rigidbody>().DOMove(character.transform.position + (skillDirection.normalized * 5 * skillDirection.magnitude) , .5f));
        character.GetComponent<PlayerController>().knockDamageRate = 5;
        character.GetComponent<SkillManager>().StartSkillCountdown(this, .5f);
        
    }

    public override void FinishSkill()
    {
        //character.GetComponent<Rigidbody>().drag = 5;
        character.GetComponent<Rigidbody>().drag = 1;
        character.GetComponent<PlayerController>().canMove = true;
        character.GetComponent<PlayerController>().knockDamageRate = 1; //CurrentKnockDamagerate - KnockDamageRate;
    }
}
