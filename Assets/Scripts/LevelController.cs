using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int score = 0;
    private int hightScore = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private PlayerController thePlayer;
    public float mapMovingSpeed = 0.05f;
    public List<PipeController> allPipe;
    public List<GroundMoving> allGround;
    public enum GameState
    {
        MainMenu, Playing, GameOver
    }
    public GameState gameState = GameState.MainMenu;
    public GameObject gameOverScreen;
    public Text gameOverScoreText;
    public Text gameOverHightScoreText;
    public GameObject startScreen;

    void Update()
    {
        if (gameState == GameState.MainMenu)
        {
            if (Input.GetButtonDown("Jump"))
            {
                StartGame();
            }
        }
    }

    public void StartGame()
    {
        startScreen.GetComponent<Animator>().SetTrigger("FadeOut");
        gameState = GameState.Playing;
        thePlayer.Play();
    }

    public void IncreasScore(int addScore)
    {
        score += addScore;
        UpdateScoreText(scoreText, score);
    }

    void UpdateScoreText(Text scoreText, int score)
    {
        scoreText.text = score + "";
    }

    public IEnumerator GameOver()
    {
        gameState = GameState.GameOver;
        for (int i = 0; i < allPipe.Count; i++)
            allPipe[i].canMove = false;
        for (int i = 0; i < allGround.Count; i++)
            allGround[i].canMove = false;
        yield return new WaitForSeconds(1);
        gameOverScreen.SetActive(true);
        if (score > hightScore)
        {
            UpdateScoreText(gameOverHightScoreText, score);
            hightScore = score;
        }
        UpdateScoreText(gameOverScoreText, score);
    }

    public void Reset()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
        gameState = GameState.GameOver;
        for (int i = 0; i < allPipe.Count; i++)
        {
            Destroy(allPipe[i].gameObject);
        }
        allPipe = new List<PipeController>();
        for (int i = 0; i < allGround.Count; i++)
            allGround[i].canMove = true;
        score = 0;
        UpdateScoreText(scoreText, score);
        thePlayer.Reset();
        gameState = GameState.MainMenu;
        startScreen.GetComponent<Animator>().SetTrigger("FadeIn");

    }

    public void Reset()
    {

    }
}
