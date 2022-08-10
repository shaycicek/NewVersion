using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public HealthBar healthBar;
    public float charHealth;
    public float currentHealth;
    public Animator animator;
    public ParticleSystem deathParticle;
    Sequence knockBackAnimation;
    public Character character;

    private void Awake()
    {
        character = GetComponent<Character>();        
        
    }
    public virtual void OnDeath()
    {
        GetComponent<Collider>().enabled = false;
        animator.SetTrigger("isDead");        
        StartCoroutine(InstantiateParticle());
    }

    IEnumerator InstantiateParticle()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(Instantiate(deathParticle, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity).gameObject, 1f);
    }

    public virtual void GetDamage(float damage)
    {
        if(GetComponent<Character>().isDead==false)
        {
            knockBackAnimation = DOTween.Sequence();
            //knockBackAnimation.Append(transform.DOMove(), 0.5f).SetEase(Ease.OutSine)))
            if(character.defenceRate != 0)
            {
                currentHealth -= damage / character.currentDefenceRate;
            }
            else
            {
                Debug.Log("def rate = 0");
            }
            
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                GetComponent<Character>().isDead = true;
                OnDeath();
            }
        }
    }
}
