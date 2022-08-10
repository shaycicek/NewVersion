using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_BasicEnemy : Brain
{
    public float movSpeed;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotL = false;
    private bool isRotR = false;
    private bool isWalking = false;
    float timer = 0;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movSpeed = GetComponent<Character>().movementSpeed;
        StartCoroutine(LateRunStateMachine());
    }

    public override void Idle()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotR == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotL == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true)
        {

            //rb.MovePosition(transform.forward * movSpeed * Time.fixedDeltaTime);            
            rb.velocity = transform.forward * movSpeed;
        }
    }
    IEnumerator LateRunStateMachine()
    {
        GetComponent<StateMachine>().enabled = true;
        yield return new WaitForSeconds(1f);
        GetComponent<StateMachine>().enabled = true;
    }

    IEnumerator Wander()
    {
        float rottime = Random.Range(0.1f, 0.3f);
        float rotwait = Random.Range(0.05f, 0.1f);
        int rotatelorR = Random.Range(1, 3);
        float walkwait = Random.Range(0.2f, 0.5f);
        float walktime = Random.Range(1, 3);


        isWandering = true;

        //yield return new WaitForSeconds(walkwait);
        isWalking = true;
        GetComponent<Character>().animator.SetBool("isMoving", true);
        yield return new WaitForSeconds(walktime);
        isWalking = false;
        rb.velocity = new Vector3(0,0,0);
        yield return new WaitForSeconds(rotwait);
        if (rotatelorR == 1)
        {
            isRotR = true;
            yield return new WaitForSeconds(rottime);
            isRotR = false;
        }
        if (rotatelorR == 2)
        {
            isRotL = true;
            yield return new WaitForSeconds(rottime);
            isRotL = false;
        }
        //GetComponent<Character>().animator.SetBool("isMoving", false);
        isWandering = false;
    }

    public void RandomWander()
    {
        //gameObject.GetComponent<Character>().movementSpeed;
    }
}
