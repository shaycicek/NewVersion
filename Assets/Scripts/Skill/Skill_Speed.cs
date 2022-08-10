using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Speed : Skill
{
    float skillTimer;
    float speedMultiplier;
    public Skill_Speed (SkillUseTypes skillUse, float speedMultiplier , float skillTimer , int cost) : base(skillUse , cost)
    {
        this.skillTimer = skillTimer;
        this.speedMultiplier = speedMultiplier;
    }
    public override void FinishSkill()
    {
        character.GetComponent<PlayerController>().SpeedSkillModifier((1/speedMultiplier));
        character.GetComponent<PlayerController>().SetSpeed();
    }

    public override void UseSkill()
    {
        GameManager.instance.ChangeValueOfCrystal(-useCost);
        character.GetComponent<SkillManager>().StartSkillCountdown(this, skillTimer);
        character.GetComponent<PlayerController>().SpeedSkillModifier(speedMultiplier);
        character.GetComponent<PlayerController>().SetSpeed();
    }
}
