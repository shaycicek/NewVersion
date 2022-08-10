using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : Interactable
{
    [SerializeField] float cost;
    [SerializeField] float health;


    public override void Interact(GameObject other)
    {
        
    }

    public virtual void Repair()
    {
        
    }
}
