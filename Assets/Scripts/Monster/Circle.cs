using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private Transform centerPos;
    private Vector3 targetPos;

    public float radius;
    public float speed;
    void Start()
    {
        centerPos = transform.parent;
        Vector2 c = new Vector2(centerPos.position.x, centerPos.position.y);
        targetPos = Random.insideUnitCircle * radius + c;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            Vector2 c = new Vector2(centerPos.position.x, centerPos.position.y);
            targetPos = Random.insideUnitCircle * radius + c;
        }
    }
}
