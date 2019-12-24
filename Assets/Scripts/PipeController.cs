using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float minPipePos = -10;
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - 0.03f, transform.position.y, transform.position.z);
        if (transform.position.x < minPipePos)
            Destroy(gameObject);
    }
}
