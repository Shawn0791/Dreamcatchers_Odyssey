using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMonsterTrigger : MonoBehaviour
{
    public SnowMonster snowMonster;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            snowMonster.StartAttack();
            Destroy(gameObject);
        }
    }
}
