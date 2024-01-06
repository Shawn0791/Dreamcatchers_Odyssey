using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PutDown();
        }
    }

    private void PutDown()
    {
        if (transform.childCount != 0)
        {
            Vector3 pos = new Vector3(transform.parent.position.x, transform.parent.position.y, -1);
            transform.GetChild(0).position = transform.parent.position;
            transform.GetChild(0).parent = transform.parent.parent;
            GameManager.instance.RefreshObjFacing();
        }
    }
}
