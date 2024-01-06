using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MonsterGetHit : MonoBehaviour
{
    private Flowchart flowchat;

    public string blockName;
    void Start()
    {
        flowchat = GameObject.FindGameObjectWithTag("Fungus").GetComponent<Flowchart>();
    }

    public void GetHit()
    {
        if (flowchat.HasBlock(blockName))
        {
            flowchat.ExecuteBlock(blockName);
        }

        Destroy(gameObject);
    }
}
