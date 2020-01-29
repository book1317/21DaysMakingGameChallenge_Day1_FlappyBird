using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoving : MonoBehaviour
{
    public float minPos = -19.23f;
    private LevelController theLevel;
    public bool canMove = true;
    void Start()
    {
        theLevel = FindObjectOfType<LevelController>();
    }

    void Update()
    {
        if (canMove)
            transform.position = new Vector3(transform.position.x - theLevel.mapMovingSpeed, transform.position.y, transform.position.z);
        if (transform.position.x < minPos)
            transform.position = new Vector3(-minPos, transform.position.y, transform.position.z);
    }
}
