using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class HouseMonster : MonoBehaviour
{
    public GameObject house_n, house_m;
    public Flowchart flowchat;
    public string blockName;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            house_n.SetActive(false);
            house_m.SetActive(true); 
            //voice start
        }
    }

    public void BackToNormal()
    {
        house_n.SetActive(true);
        house_m.SetActive(false);
        //voice stop

        if (flowchat.HasBlock(blockName))
        {
            flowchat.ExecuteBlock(blockName);
        }

    }
}
