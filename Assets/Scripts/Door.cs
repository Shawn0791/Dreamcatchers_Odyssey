using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private GameObject good1, good2;
    private void Start()
    {
        good1 = GameObject.FindGameObjectWithTag("GameManager").transform.GetChild(0).gameObject;
        good2 = GameObject.FindGameObjectWithTag("GameManager").transform.GetChild(1).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckState();
        }
    }

    private void CheckState()
    {
        if (good1.activeSelf && good2.activeSelf)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
