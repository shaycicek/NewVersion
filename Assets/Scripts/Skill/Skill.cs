using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill 
{
    public GameObject particleEffect;
    public Character character;
    public Vector3 skillDirection;
    public int skillLevel; // ??
    public int upgradeCost; // ??
    public int useCost;
    public float energyTimer;
    public enum SkillUseTypes
    {
        HoldToUse,
        HoldToAim,
        ClickToUse,
    }
    public SkillUseTypes skillUseType;
    // public abstract int UseCost {get:  };
    public abstract void UseSkill();
    public Skill (SkillUseTypes skillUse ,int cost)
    {
        skillUseType = skillUse;
        useCost = cost;
    }

    public virtual void Initialize(Character player)
    {
        character = player;
    }

    public virtual void FinishSkill()
    {

    }

    public virtual void SetSkillDirection(Vector3 skillDirection)
    {
        this.skillDirection = skillDirection;
    }



    public int UseCost
    {
        get
        {
            return useCost;
        }
        set
        {
            useCost = value;
        }
    }


}
