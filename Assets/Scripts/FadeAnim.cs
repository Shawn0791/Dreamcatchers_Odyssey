using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnim : MonoBehaviour
{
    public Transform insidePos;
    public Transform outsidePos;
    public GameObject player;
    public void EnterDoor()
    {
        player.transform.position = insidePos.position;
    }

    public void OutDoor()
    {
        player.transform.position = outsidePos.position;
    }
}
