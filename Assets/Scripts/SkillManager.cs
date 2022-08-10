using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public void StartSkillCountdown(Skill skill , float time)
    {
        StartCoroutine(FinishSkillAfterTime(skill, time));
    }

    IEnumerator FinishSkillAfterTime(Skill skill , float time)
    {
        yield return new WaitForSeconds(time);
        skill.FinishSkill();
    }

}
