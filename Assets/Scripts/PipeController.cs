using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float minPipePos = -10;
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

        if (transform.position.x < minPipePos)
        {
            theLevel.allPipe.Remove(this);
            Destroy(gameObject);
        }
    }
}