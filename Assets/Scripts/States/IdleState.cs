using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public FollowState followState;
    public bool canSeeThePlayer=false;

    public override void OnEnterState()
    {
        self.animator.SetBool("isMoving", false);
    }

    public override void OnExitState()
    {

    }

    public override State RunCurrentState()
    {
        canSeeThePlayer = Physics.CheckSphere(transform.position, 
        GetComponent<Character>().sightRange, 
        GetComponent<Character>().enemy);

        if(canSeeThePlayer)
        {

            return followState;
        } else
        {
            GetComponent<Brain_BasicEnemy>().Idle();
            return this;
        }
        
    }
}
