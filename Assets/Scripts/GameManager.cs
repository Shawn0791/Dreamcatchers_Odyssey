using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Flowchart flowchat;

    public FacingCamera[] scripts;
    private void Awake()
    {
        instance = this;
    }

    public void RefreshObjFacing()
    {
        for (int i = 0; i < scripts.Length; i++)
        {
            scripts[i].RefreshFacing();
        }
    }
}
