using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally_AttackState : State

{
    public Ally_ChaseEnemy chaseEnemy;

    public override void OnEnterState()
    {
        self.animator.SetBool("isAttacking", true);
    }

    public override void OnExitState()
    {
        self.animator.SetBool("isAttacking", false);
    }


    public override State RunCurrentState()
    {
        playerisAttacking = player.isAttacking;
        GetComponent<Character>().isAttacking = playerisAttacking;
        if (player.FindClosestEnemy(player.transform.position, player.myWeapon.range) != null)
        {
            if ((transform.position - player.FindClosestEnemy(player.transform.position, player.myWeapon.range).position).magnitude
           <= self.attackRange)
            {
                gameObject.transform.LookAt(GetComponent<Character>().FindClosestEnemy(transform.position,
                    self.attackRange));
                //gameObject.transform.Rotate(0.0f, 55.0f, 0.0f);
                self.Attack();
                return this;
            }
            else if ((transform.position - player.FindClosestEnemy(player.transform.position, player.myWeapon.range).position).magnitude > GetComponent<Character>().attackRange)
            {
                return chaseEnemy;
            }
        }
        return chaseEnemy;
    }
}