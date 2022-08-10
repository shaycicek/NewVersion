using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationStateController : MonoBehaviour
{
    bool isDead;
    bool isAttacking;
    bool isMoving;
    int isMovingHash;
    int isAttackingHash;
    int isDeadHash;
    public Animator animator;
    private void Awake()
    {
        /*animator = GetComponent<Animator>();
        isDead = GetComponent<Character>().isDead;
        isAttacking = GetComponent<Character>().isAttacking;
        isMoving = GetComponent<Character>().isMoving;
        isDeadHash = Animator.StringToHash("isDead");
        isAttackingHash = Animator.StringToHash("isAttacking");
        isMovingHash = Animator.StringToHash("isMoving");
        animator.SetBool("isDead", isDead);
        animator.SetBool(isMovingHash, isMoving);
        animator.SetBool(isAttackingHash, isAttacking); */

    }
    private void Update()
    {



    }



}
