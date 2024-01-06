using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeOutdoor : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("Enter");
        }
    }
}
