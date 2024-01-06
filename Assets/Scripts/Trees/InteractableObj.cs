using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class InteractableObj : MonoBehaviour
{
    private Flowchart flowchat;
    private bool interactable;

    public string blockName;
    void Start()
    {
        flowchat = GameObject.FindGameObjectWithTag("Fungus").GetComponent<Flowchart>();
    }

    void Update()
    {
        if (interactable)
            Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            interactable = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            interactable = false;
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flowchat.HasBlock(blockName))
            {
                flowchat.ExecuteBlock(blockName);
            }
        }
    }
}
