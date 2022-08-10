using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : Interactable
{
    public float interactTime;
    float timer=0;
    public Effect shrineEffect;
    public override void Interact(GameObject other)
    {
        shrineEffect.RunEffect();
    }

    private void OnTriggerStay(Collider other)
    {
        if(timer < interactTime)
        {
            timer += Time.deltaTime;
        }else
        {
            Interact(other.gameObject);
        }
        
    }


}
