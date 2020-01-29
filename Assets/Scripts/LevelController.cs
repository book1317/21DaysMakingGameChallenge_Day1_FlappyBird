using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int score = 0;
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
        gameState = GameState.Playing;
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

    public IEnumerator GameOver()
    {
        gameState = GameState.GameOver;
        for (int i = 0; i < allPipe.Count; i++)
            allPipe[i].canMove = false;
        for (int i = 0; i < allGround.Count; i++)
            allGround[i].canMove = false;
        yield return new WaitForSeconds(2);
        gameOverScreen.SetActive(true);

    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
