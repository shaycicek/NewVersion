using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer_Proj : Projectile
{
    public float projectileRadius;
    public float throwTime;
    float timer;
    float t;
    Transform enemyPos;
    public float speed;

    float startTime;
    Vector3 centerPoint;
    Vector3 startRelCenter;
    Vector3 endRelCenter;

    private void Start()
    {
        t = 0;
        timer = 0;
        //StartCoroutine(ThrowRoutine());
    }
    private void Update()
    {
        GetCenter(transform.up);
        float fracComplete = (Time.time - startTime) / throwTime * speed;
        transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete * speed);
        transform.position += centerPoint;
    }


    public override void OnHit(Health health)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, projectileRadius, enemy);
        foreach (var hitCollider in hitColliders)
        {
            if (!hitCollider.gameObject.GetComponent<Character>().isDead)
            {
                hitCollider.gameObject.GetComponent<Health>();
            }
        }
        model.SetActive(false);
        Destroy(gameObject, .2f);
    }

    IEnumerator ThrowRoutine()
    {
        while (timer < throwTime)
        {

            yield return null;
        }
            


        /*while (timer<throwTime)
        {
            timer += Time.fixedDeltaTime;
            t = timer / throwTime;            
            transform.position = Vector3.Slerp(transform.position, enemyPos.position + new Vector3(0,1f,0), t);
            Debug.Log(transform.position);
            
        }*/

    }

    public void GetCenter(Vector3 direction)
    {
        centerPoint = (transform.position + enemyPos.position) * .5f;
        centerPoint -= direction;
        startRelCenter = transform.position - centerPoint;
        endRelCenter = enemyPos.position - centerPoint;
    }


    public void EnemyPosInit(Transform enemyPos)
    {
        this.enemyPos = enemyPos;
    }


}
