using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CourtManager : MonoBehaviour {
    Canvas courtCanvas;
    Image cImage;

    GameObject court;
    GameObject ball;

    float cWidth, cHeight;
    float wWidth, wHeight;

    int p1Score = 0;
    int p2Score = 0;

    bool gameRunning;

    Vector2 prevStartDir;

    public Text p1ScoreText;
    public Text p2ScoreText;
    public Text p1EndText;
    public Text p2EndText;

    public AudioClip[] ballClips;

    public CanvasGroup endGame;

    public GameObject endGameObject;

    // Use this for initialization
    void Start () {
        ball = GameObject.Find("ball");
        courtCanvas = FindObjectOfType<Canvas>();
        court = courtCanvas.transform.GetChild(0).gameObject;
        cImage = court.GetComponent<Image>();
        gameRunning = true;
        endGame.interactable = false;
        endGame.blocksRaycasts = false;

        endGameObject.SetActive(false);

        SetupGame();
    }

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

    void SetupGame()
    {
        ball.transform.position = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();

        Vector2 startDir = Vector2.zero;
        while(startDir == Vector2.zero || startDir.x == 0 || ((startDir.x <= 0.0f && startDir.x > -0.7) && ((startDir.y <= 1 && startDir.y > 0.7f) && startDir.y == -1) || (startDir.x == 0.1f && (startDir.y >= -1.0f && startDir.y < -0.3f))))
        {
            startDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            Debug.Log("StartDir: " + startDir);
        }
        startDir.Normalize();
        ball.GetComponent<Rigidbody2D>().AddForce(startDir * 10f, ForceMode2D.Impulse);

        prevStartDir = startDir;
    }

    void FixedUpdate()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(ball.GetComponent<Rigidbody2D>().velocity, 8f);
    }

    public void Bounced()
    {
        GetComponent<AudioSource>().PlayOneShot(ballClips[0]);
    }

    public bool GameRunning
    {
        get { return gameRunning; }
        set { gameRunning = value; EndGame(); }
    }

    void EndGame()
    {
        endGameObject.SetActive(true);
        endGame.interactable = true;
        endGame.blocksRaycasts = true;
        
        if(p1Score > p2Score)
        {
            p1EndText.text = "Winner";
            p2EndText.text = "Loser";
        }
        else if(p1Score == p2Score)
        {
            p1EndText.text = "TIE";
            p2EndText.text = "TIE";
        }
        else
        {
            p1EndText.text = "Loser";
            p2EndText.text = "Winner";
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
