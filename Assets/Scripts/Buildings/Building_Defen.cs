using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Defen : Building
{
    [SerializeField] Transform bulletHole;
    [SerializeField] LayerMask enemy;
    [SerializeField] float attackRange;
    [SerializeField] float damageFactor;
    [SerializeField] float fireRate;
    public Projectile projectile;

    private void Update()
    {
        if(FindClosestEnemy(transform.position , attackRange) != null)
        {
            Attack();
        }
        
    }
    public void Attack()
    {
        transform.LookAt(FindClosestEnemy(transform.position, attackRange));
        /*Projectile proj = Instantiate(projectile);
        proj.transform.position = bulletHole.position;*/
    }

    public Transform FindClosestEnemy(Vector3 center, float radius)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius, enemy);
        foreach (var hitCollider in hitColliders)
        {
            if (!hitCollider.gameObject.GetComponent<Character>().isDead)
            {
                Vector3 directionToTarget = hitCollider.gameObject.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;

                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = hitCollider.gameObject.transform;
                }
            }
        }
        return bestTarget;
    }
}
