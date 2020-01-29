using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] LevelController theLevel;
    public float jumpForce = 5;
    public float maxFlipFaceAngle = 25;
    public float minFlipFaceAngle = -65;
    private float lastFlipFaceAngle = -65;
    private float flipAngle;
    public int minflipFaceVelocity = 2;
    public int maxflipFaceVelocity = 4;
    public bool headUp = false;
    void Start()
    {
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.isKinematic = true;
    }

    void Update()
    {
        if (theLevel.isStart)
        {
            if (Input.anyKey)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }
            }

            if (headUp)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 5f);
                if (transform.eulerAngles.z >= maxFlipFaceAngle || myRigidbody.velocity.y < maxflipFaceVelocity)
                    headUp = false;
            }
            else if (myRigidbody.velocity.y >= maxflipFaceVelocity)
            {
                flipAngle = 25.0f;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, flipAngle);
            }
            else if (myRigidbody.velocity.y > minflipFaceVelocity)
            {
                flipAngle = Mathf.Abs((minflipFaceVelocity - myRigidbody.velocity.y) / (maxflipFaceVelocity - minflipFaceVelocity) * (maxFlipFaceAngle - minFlipFaceAngle)) + minFlipFaceAngle;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, flipAngle);
            }
        }
    }

    public void Jump()
    {
        myRigidbody.velocity = new Vector3(0, jumpForce, 0);
        lastFlipFaceAngle = transform.eulerAngles.z;
        headUp = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipe"))
            Death();
        else if (other.CompareTag("PipeDetector"))
        {
            theLevel.IncreasScore(1);
            Destroy(other.gameObject);
        }
    }

    void Death()
    {
        Reset();
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Play()
    {
        myRigidbody.isKinematic = false;
        Jump();
    }
}
