using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster_Projectile : Projectile
{
    public float castRadius;
    [SerializeField] GameObject innerCircle;
    public ParticleSystem destroyingParticle;
    private void Start()
    {        
        innerCircle.transform.DOScale(new Vector3(2.2f, 2.2f, 25f), 2f).SetEase(Ease.OutSine).OnComplete(() => Destroy(gameObject));
    }

    private void OnDestroy() // Sorcere Projdaki gibi yap
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, castRadius, enemy);
        foreach (var hitCollider in hitColliders)
        {
            if (!hitCollider.gameObject.GetComponent<Character>().isDead)
            {
                OnHit(hitCollider.gameObject.GetComponent<Health>());
            }
        }
        //Destroy(Instantiate(destroyingParticle , transform.position , Quaternion.identity),1f);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, castRadius);
    }
}
