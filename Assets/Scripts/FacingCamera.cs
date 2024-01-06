using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour
{
    Transform[] childs;

    //public static FacingCamera instance;
    //private void Awake()
    //{
    //    instance = this;
    //}
    void Start()
    {
        RefreshFacing();
    }

    public void RefreshFacing()
    {
        childs = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childs[i] = transform.GetChild(i);
        }

        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].rotation = Camera.main.transform.rotation;
        }
    }
}
