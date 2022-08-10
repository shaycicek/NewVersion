using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzledState : State
{
    public FollowState followState;
    public IdleState idleState;
    public bool canSeeThePlayer = false;
    float timer=0;
    public override void OnEnterState()
    {
        self.animator.SetBool("isMoving", false);
        self.animator.SetTrigger("isKnocked");
        self.animator.SetBool("isStunned", true);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 45f, 0f));
        GetComponent<Rigidbody>().drag = 5;
        //GetComponent<Health>().GetDamage(2);
        Physics.gravity = new Vector3(0, -28, 0);
    }

    public override void OnExitState()
    {
        timer = 0;        
        self.animator.SetBool("isStunned", false);
        self.isStunned = false;
        GetComponent<Rigidbody>().drag = 1;
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    public override State RunCurrentState()
    {
        canSeeThePlayer = Physics.CheckSphere(transform.position, self.sightRange , GetComponent<Character>().enemy);
        timer += Time.deltaTime;
        
        if (timer>=1)
        {
            if(canSeeThePlayer)
            {
                return followState;
            }
            else
            {
                return idleState;
            }
            
        }else
        {
            return this;
        }

    }
}
