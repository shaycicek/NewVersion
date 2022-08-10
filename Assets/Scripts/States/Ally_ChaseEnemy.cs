using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally_ChaseEnemy : State
{
    public Ally_AttackState attackState;
    public Ally_FollowState followState;

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
            return followState;
        }
        else if (player.FindClosestEnemy(player.transform.position, player.myWeapon.range) != null)
        {
            if ((transform.position - player.FindClosestEnemy(player.transform.position, player.myWeapon.range).position).magnitude
           > GetComponent<Character>().attackRange)
            {
                transform.LookAt(player.FindClosestEnemy(player.transform.position, player.myWeapon.range));
                GetComponent<Rigidbody>().MovePosition(transform.position +
                    (player.FindClosestEnemy(player.transform.position, player.myWeapon.range).position - transform.position).normalized
                    * GetComponent<Character>().movementSpeed * Time.fixedDeltaTime);
                return this;
            }
            else if ((transform.position - player.FindClosestEnemy(player.transform.position, player.myWeapon.range).position).magnitude <= GetComponent<Character>().attackRange)
            {
                return attackState;
            }
        }


        return followState;
    }
}