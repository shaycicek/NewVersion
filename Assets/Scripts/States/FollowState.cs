using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public AttackState attackState;
    public IdleState idleState;
    public DizzledState dizzledState;
    public bool isInAttackRange;
    public bool canSeeThePlayer;
    public float nextStateTimer = 2.0f;
    float timer;

    public override void OnEnterState()
    {

        self.animator.SetBool("isMoving", true);
        timer = 0;
    }

    public override void OnExitState()
    {
        self.animator.SetBool("isMoving", false);
        timer = 0;
    }
    public override State RunCurrentState()
    {
          // Moving Anim True
        isInAttackRange = Physics.CheckSphere(transform.position, 
            GetComponent<Character>().attackRange, 
            GetComponent<Character>().enemy);
        canSeeThePlayer = Physics.CheckSphere(transform.position, 
            GetComponent<Character>().sightRange, 
            GetComponent<Character>().enemy);

        if (!self.isStunned)
        {
            if (isInAttackRange)
            {

                return attackState;
            }
            else if (!canSeeThePlayer)
            {
                timer += Time.deltaTime;
                if (timer >= nextStateTimer)
                {
                    return idleState;
                }
                return this;
            }
            else
            {
                timer = 0;
                GetComponent<Brain_BasicEnemy>().Follow();
                return this;
            }
        } else
        {
            return dizzledState;
        }

       
    }
}
