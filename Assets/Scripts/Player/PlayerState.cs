using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Animator animator;
    public void PlayerDead()
    {
        animator.SetTrigger("Enter");
    }
}
