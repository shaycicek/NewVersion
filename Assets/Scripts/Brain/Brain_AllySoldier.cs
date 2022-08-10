using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_AllySoldier : Brain
{
    Character player;
    public override void Follow()
    {
        
        Vector3 direction = player.transform.position - transform.position;
        rb.MovePosition(transform.position + direction.normalized * ch.movementSpeed * Time.fixedDeltaTime);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ch = GetComponent<Character>();
        wp = ch.myWeapon;
        //player = GameManager.instance.player;
    }
    private void Update()
    {
        if(ch.FindClosestEnemy(transform.position , ch.myWeapon.range)!= null)
        {
            gameObject.transform.LookAt(ch.FindClosestEnemy(transform.position, ch.myWeapon.range));
            ch.Attack();
                
        }
        

    }
    public override void Idle()
    {

    }
}
