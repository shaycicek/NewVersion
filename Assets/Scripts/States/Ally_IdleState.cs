using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally_IdleState : State

{
    public Ally_FollowState followState;
    public Ally_ChaseEnemy chaseState;
    public override void OnEnterState()
    {
        self.animator.SetBool("isMoving", false);
    }

    public override void OnExitState()
    {

    }

    public override State RunCurrentState()
    {
        if (player.isMoving)
        {
            return followState;
        }
        else if (playerisAttacking)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

}