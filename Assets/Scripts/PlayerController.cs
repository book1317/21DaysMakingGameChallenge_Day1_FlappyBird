using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] LevelController theLevel;
    public float jumpForce = 5;
    public int maxFlipFaceAngle = 20;
    private float flipAngle;
    public int minMaxflipFaceVelocity = 4;
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

            if (myRigidbody.velocity.y > -minMaxflipFaceVelocity && myRigidbody.velocity.y < minMaxflipFaceVelocity)
            {
                flipAngle = myRigidbody.velocity.y / minMaxflipFaceVelocity * maxFlipFaceAngle;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, flipAngle);
            }
        }
    }

    public void Jump()
    {
        myRigidbody.velocity = new Vector3(0, jumpForce, 0);
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
