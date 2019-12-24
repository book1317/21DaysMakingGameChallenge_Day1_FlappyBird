using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public int score = 0;
    public bool isStart = false;
    [SerializeField] private Text scoreText;
    [SerializeField] private PlayerController thePlayer;
    void Start()
    {

    }

    void Update()
    {
        if (Input.anyKey && !isStart)
        {
            if (Input.GetButtonDown("Jump"))
            {
                StartGame();
            }
        }
    }

    public void StartGame()
    {
        isStart = true;
        thePlayer.Play();
    }

    public void IncreasScore(int addScore)
    {
        score += addScore;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = score + "";
    }
}
