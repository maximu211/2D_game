using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerSetting player;

    public Animator animator;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

    }

    public void Attack()
    {
        switch(player.type) 
        {
            case 1:
                animator.SetBool("IsJumping", false);
                animator.SetTrigger("AttackSword");
                break;
            case 2:
                animator.SetBool("IsJumping", false);
                animator.SetTrigger("AttackBow");
                break;
        }
    }
}
