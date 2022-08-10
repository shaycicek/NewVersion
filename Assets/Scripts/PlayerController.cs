using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool canMove;
    public float knockDamageRate;
    public float startSpeed;
    public float currentSpeed;
    public float speedModifier;
    float slowSpeed;
    bool slowed;
    public FixedJoystick movementJoystick;
    public Rigidbody rb;
    public Character character;
    public Transform mainCharacter;
    public FixedJoystick shootingJoystick;
    public Button attackButton;
    public List<GameObject> slowerList = new List<GameObject>();
    float timer=0;
    public delegate void OnButtonSelectDelegate();
    public OnButtonSelectDelegate OnButtonSelect;

    private void Awake()
    {
        canMove = true;
        character = GetComponent<Character>();
        startSpeed = character.movementSpeed;
        slowSpeed = startSpeed/3;
        speedModifier = 1;
        OnButtonSelect += Aim;


    }
    private void Start()
    {
        currentSpeed = startSpeed;
        slowed = false;
        
    }

    private void OnDisable()
    {
        
    }
    public void FixedUpdate()
    {
        Attack();
        if(canMove)
        {
            Move();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyKnockBack"))
        {
            AddSlowerList(other.gameObject);
            other.GetComponentInParent<Character>().isStunned = true;
            other.GetComponentInParent<Rigidbody>().AddForce(transform.forward*25 + transform.up * 25 , ForceMode.Impulse);
            other.GetComponentInParent<Health>().GetDamage(knockDamageRate);
            StartCoroutine(RemoveSlowerList(other.gameObject));
        }
    }

    public void SetSpeed()
    {
        if (slowed)
        {
            currentSpeed = (slowSpeed) * (speedModifier);
        }
        else
        {
            currentSpeed = (startSpeed) * (speedModifier);
        }
    }
    public void EnterSlow()
    {
        slowed = true;
        currentSpeed = (slowSpeed) * (speedModifier);
        //currentSpeed = slowSpeed;
    }

    public void ExitSlow()
    {
        slowed = false;
        currentSpeed = (startSpeed) * (speedModifier);
        //currentSpeed = startSpeed;
    }

    public void Attack()
    {
        //mainCharacter.transform.Rotate(-mainCharacter.transform.rotation.x + 5.0f, mainCharacter.rotation.y + 53.0f, 0.0f);
        if (Physics.CheckSphere(transform.position, character.myWeapon.range, character.enemy))
        {            
            character.isAttacking = true;
            //Aim();
        } else
        {
            character.isAttacking = false;
        }        
    }

    public void SpeedSkillModifier(float speed)
    {
        this.speedModifier *= speed;
    }

    public void AddSlowerList(GameObject gameobject)
    {
        if (slowerList.Count <= 0)
        {         
            EnterSlow();
        }
        slowerList.Add(gameobject);
    }
    public IEnumerator RemoveSlowerList(GameObject gameObject)
    {
        yield return new WaitForSeconds(.1f);

        RemoveFromSlowerList(gameObject);

    }
    public void RemoveFromSlowerList(GameObject gameObject)
    {
        slowerList.Remove(gameObject);
        if (slowerList.Count <= 0)
        {
            ExitSlow();
        }        
    }

    public void Aim()
    {
        character.Attack();
        mainCharacter.transform.LookAt(character.FindClosestEnemy(transform.position, character.attackRange));
        //mainCharacter.transform.LookAt(transform.position + (Vector3.forward * shootingJoystick.Vertical + Vector3.right * shootingJoystick.Horizontal).normalized);
        if(Physics.CheckSphere(transform.position, character.myWeapon.range, character.enemy))
        {
            mainCharacter.transform.Rotate(-mainCharacter.transform.rotation.x + 5.0f, mainCharacter.rotation.y + 53.0f, 0.0f);
        }
        
    }

    public void Move()
    {
        if (movementJoystick.Vertical != 0 && movementJoystick.Horizontal != 0)
        {
            character.isMoving = true;
            Vector3 move = Vector3.forward * movementJoystick.Vertical + Vector3.right * movementJoystick.Horizontal;
            //rb.MovePosition(transform.position + move * Time.fixedDeltaTime * currentSpeed);
            rb.velocity = (move * currentSpeed);
            Vector3 lookTarget = transform.position + move.normalized;
            transform.LookAt(lookTarget);
            Vector3 direction = lookTarget - transform.position;
            if (!character.isAttacking)
            {
                //character.model.transform.LookAt(lookTarget); //BAKILACAK ?
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            character.isMoving = false;
        }
    }

    public void Teleport(Transform transformPos)
    {
        this.transform.position = transformPos.position;
    }
    

    public void SkillUsed()
    {

    }

    public void ButtonSelected()
    {
        OnButtonSelect?.Invoke();
    }
}
