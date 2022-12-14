
using UnityEngine;


public class Character : MonoBehaviour
{
    public enum CharacterClasses
    {
        Ally_Basic,
        Ally_Melee,
        Ally_Archer,
        Ally_Sorcerer,        
        Ally_Rally,
        Ally_Fearmancer,
        Ally_Buff,
        Ally_Engineer,
        Player,
        Enemy_Melee,
        Enemy_Caster,        
        Enemy_Basic
    }
    public CharacterClasses characterClasses;

    public int charLevel = 1;

    //Anim State Bools;
    public Animator animator;
    public bool isDead;
    public bool isAttacking;
    public bool isMoving;
    public bool isStunned;
    public bool immnuneToKnockBack;
    //Char Variables
    public float damageFactor; // Damage Çarpanı
    public Weapon myWeapon;
    public float movementSpeed;
    public float attackRange;
    public float sightRange;
    public GameObject model;
    public float attackRateFactor;
    public float currentDefenceRate;
    public float defenceRate ;
    
    //
    public LayerMask player;
    public LayerMask enemy;
    public LayerMask ally;
    //
    public float minRange;
    float timer;

    private void Start()
    {
        defenceRate = 1;
        currentDefenceRate = defenceRate;
        isDead = false;
        timer = 0;
        // game manager yada inventory      
    }

    public void Attack ()
    {
        timer += Time.deltaTime;
        if (timer>=attackRateFactor*myWeapon.AttackRate) {
            //mainCharacter.LookAt(FindClosestEnemy(transform.position, myWeapon.range).position);
            isAttacking = true;
            myWeapon.InitializeWeapon(this, enemy, damageFactor);
            myWeapon.Attack();
            timer = 0;
        }
        else
        {
            isAttacking = false;
        }
    }

    public void Move(Vector2 movementInput)
    {
                //Yapılacak!!!!
    }

    // defaultMove fonksiyonuyla karakterin verdiğimiz Vector3 pozisyonuna direkt olarak gitmesini sağlayacagız.
    public void DefaultMove(Vector3 vector)  
    {
        //Yapılacak!!
    }

    public void Interact(Interactable interactable)
    {

    }

    public void LookAtDirection(/*içine bir şey gelecek mi ?*/ )
    {
    }

    public void SetWeapon(Weapon weapon)
    {
        myWeapon = weapon;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            Interact(other.GetComponent<Interactable>());            
        }
    }

    public Transform FindClosestEnemy(Vector3 center , float radius)
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

    public void SetCharLevel(int i)
    {
        this.charLevel = i;
    }

    public Transform GetClosestEnemy()
    {
        return FindClosestEnemy(transform.position, attackRange);
    }
    
    public void Initialize(float charHealth , float damageFactor , float movementSpeed , float attackRange , float sightRange)
    {
        
        if (damageFactor != 0)
        {
            this.damageFactor = damageFactor;
        }

        if(charHealth!=0)
        {
            GetComponent<Health>().charHealth = charHealth;
        }        
        this.movementSpeed = movementSpeed;
        this.attackRange = attackRange;
        this.sightRange = sightRange;
        isDead = false;
        isAttacking = false;
        isMoving = false;
        isStunned = false;
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, minRange);
    }
}
