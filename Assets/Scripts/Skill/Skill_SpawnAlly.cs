using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_SpawnAlly : Skill
{

    public Skill_SpawnAlly(SkillUseTypes skillUse, int cost) : base(skillUse , cost)
    {
    }

    public override void UseSkill()
    {
        
        if(GameManager.instance.crystalCount>=UseCost)
        {
            GameManager.instance.ChangeValueOfCrystal(-useCost);
            for (int i = 0; i < 5; i++)
            {
                SpawnManager.instance.SpawnAlly(character.transform.position);
            }
            
        }

        
    }

}
