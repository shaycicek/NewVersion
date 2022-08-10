using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public Character player;
    public Character self;
    public bool playerisAttacking;

    public virtual void Start()
    {
        self = GetComponent<Character>();
        player = GameManager.instance.player;
        playerisAttacking = GameManager.instance.player.isAttacking;
    }


    public abstract State RunCurrentState();

    public virtual void OnEnterState()
    {

    }
    public virtual void OnExitState()
    {

    }
}
