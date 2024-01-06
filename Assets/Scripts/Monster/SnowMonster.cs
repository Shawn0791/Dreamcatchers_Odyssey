using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SnowMonster : MonoBehaviour
{
    private Transform player;
    private Vector3 target;
    private bool isWeak;
    private float timer;

    public BoxCollider2D attackArea;
    public float speed;
    public float waitTime;
    public bool beginAttack;

    private Flowchart flowchat;

    public string blockName;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        flowchat = GameObject.FindGameObjectWithTag("Fungus").GetComponent<Flowchart>();
    }

    void Update()
    {
        if (beginAttack && !isWeak) 
        {
            AttackMovement();
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            StartAttack();
        }
    }

    public void StartAttack()
    {
        target = player.position;
        beginAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerState>().PlayerDead();
        }
        else if (collision.CompareTag("Torch"))
        {
            isWeak = true;
            attackArea.enabled = false;
        }
    }

    private void AttackMovement()
    {


        if (Vector3.Distance(transform.position, target) < 0.5f)
        {
            timer -= Time.deltaTime;
            attackArea.enabled = false;

            if (timer < 0)
            {
                target = player.position;
                timer = waitTime;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            attackArea.enabled = true;
        }
    }

    public void GetHit()
    {
        if (isWeak)
        {
            if (flowchat.HasBlock(blockName))
            {
                flowchat.ExecuteBlock(blockName);
            }

            Destroy(gameObject, 2);
        }
    }
}
