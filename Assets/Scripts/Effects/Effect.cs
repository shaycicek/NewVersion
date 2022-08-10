using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public float lifetime;
    public Character character;
    public abstract void FinishSkill();
    public virtual void RunEffect()
    {
        StartCoroutine(FinishEffectAfterTime(this , lifetime));
    }



    IEnumerator FinishEffectAfterTime(Effect effect, float time)
    {
        yield return new WaitForSeconds(time);
        effect.FinishSkill();
    }

    public virtual void Initialize(Character player)
    {
        character = player;
    }

}
