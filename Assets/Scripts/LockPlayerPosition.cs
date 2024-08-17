using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerPosition : MonoBehaviour
{
    void Update()
    {
        Vector3 position = transform.position;
        position.y = 180;
        transform.position = position;
    }
}
