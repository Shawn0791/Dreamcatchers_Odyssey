using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10);
    }
}
