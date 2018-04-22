using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CourtManager : MonoBehaviour {
    Image cImage;

    GameObject court;
    GameObject ball;

    float cWidth, cHeight;
    float wWidth, wHeight;

    int p1Score = 0;
    int p2Score = 0;

    bool gameRunning;

    public Text p1ScoreText;
    public Text p2ScoreText;
    public Text p1EndText;
    public Text p2EndText;

    public AudioClip[] ballClips;

    public CanvasGroup endGame;

    public GameObject endGameObject;

    void Start () {
        ball = GameObject.Find("ball");
        gameRunning = true;
        endGame.interactable = false;
        endGame.blocksRaycasts = false;
        endGameObject.SetActive(false);

        SetupGame();
    }

    /// <summary>
    /// Increments a player's score by 1, player is determined by bool isP1 (true = P1, false = P2).
    /// </summary>
    /// <param name="isP1">Bool for determining which player scored.</param>
    public void UpdateScore(bool isP1)
    {
        if (gameRunning)
        {
            if (isP1)
            {
                p1Score++;
                p1ScoreText.text = p1Score.ToString();
                GetComponent<AudioSource>().PlayOneShot(ballClips[1]);
            }
            else
            {
                p2Score++;
                p2ScoreText.text = p2Score.ToString();
                GetComponent<AudioSource>().PlayOneShot(ballClips[1]);
            }
            SetupGame();
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Sets the spawn position and direction of the game ball.
    /// </summary>
    void SetupGame()
    {
        Vector3 spawnPos = new Vector3(0, Random.Range(-440, 440), -1);
        ball.transform.localPosition = spawnPos;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();

        Vector2 startDir = Vector2.zero;
        startDir = new Vector2(Random.value > 0.5f ? -1 : 1, Random.Range(-1.00f, 1.00f));
        startDir.Normalize();
        ball.GetComponent<Rigidbody2D>().AddForce(startDir * 10f, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(ball.GetComponent<Rigidbody2D>().velocity, 8f);
    }

    /// <summary>
    /// Play audioClip on every bounce.
    /// </summary>
    public void Bounced()
    {
        GetComponent<AudioSource>().PlayOneShot(ballClips[0]);
    }

    /// <summary>
    /// Whether or not gameplay is running and metrics are being recorded.
    /// </summary>
    public bool GameRunning
    {
        get { return gameRunning; }
        set { gameRunning = value; EndGame(); }
    }

    /// <summary>
    /// Terminates gameplay and displays result of win condition check.
    /// </summary>
    void EndGame()
    {
        endGameObject.SetActive(true);
        endGame.interactable = true;
        endGame.blocksRaycasts = true;
        
        if(p1Score > p2Score) { p1EndText.text = "Winner"; p2EndText.text = "Loser"; }
        else if(p1Score == p2Score) { p1EndText.text = "TIE"; p2EndText.text = "TIE"; }
        else { p1EndText.text = "Loser"; p2EndText.text = "Winner"; }
    }

    /// <summary>
    /// Return to the main menu.
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
