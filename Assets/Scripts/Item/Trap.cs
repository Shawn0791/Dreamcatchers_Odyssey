using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator animator;
    private GameObject monster;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            animator.SetTrigger("Kaba");
            monster = collision.gameObject;
            Destroy(transform.parent.gameObject, 5);
        }
        else if (collision.CompareTag("SnowMonster"))
        {
            animator.SetTrigger("Kaba");
            collision.GetComponent<SnowMonster>().GetHit();
            Destroy(transform.parent.gameObject, 5);
        }
    }

    public void KillMonster()
    {
        monster.GetComponent<MonsterGetHit>().GetHit();
    }
}
