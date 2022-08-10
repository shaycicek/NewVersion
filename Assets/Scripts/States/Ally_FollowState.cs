using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally_FollowState : State
{
    //public Ally_AttackState attackState;
    public Ally_ChaseEnemy chaseEnemy;
    public Ally_IdleState idleState;
    public override void OnEnterState()
    {
        self.animator.SetBool("isMoving", true);
    }

    public override void OnExitState()
    {
        self.animator.SetBool("isMoving", false);
    }

    public override State RunCurrentState()
    {
        playerisAttacking = player.isAttacking;
        if (!playerisAttacking)
        {
            if (!player.isMoving)
            {
                return idleState;
            }
            else if ((transform.position - player.transform.position).magnitude <= GetComponent<Character>().minRange)
            {
                GetComponent<Character>().isMoving = false;
            }
            else
            {
                // if (Physics.CheckSphere(transform.position, ch.sightRange, ch.player))
                GetComponent<Character>().isMoving = true;
                Vector3 direction = player.transform.position - transform.position;
                transform.LookAt(player.transform);
                //GetComponent<Rigidbody>().velocity = Vector3.forward * GetComponent<Character>().movementSpeed;
                GetComponent<Rigidbody>().MovePosition(transform.position + direction.normalized * GetComponent<Character>().movementSpeed * Time.fixedDeltaTime);
                
            }
            return this;
        }
        else
        {
            return chaseEnemy;
        }


    }
}