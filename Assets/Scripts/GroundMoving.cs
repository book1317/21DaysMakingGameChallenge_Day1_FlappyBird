using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoving : MonoBehaviour
{
    public float minPos = -19.23f;
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - 0.03f, transform.position.y, transform.position.z);
        if (transform.position.x < minPos)
            transform.position = new Vector3(-minPos, transform.position.y, transform.position.z);
    }
}
