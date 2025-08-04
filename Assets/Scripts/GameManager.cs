using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instantion { get; private set; }
    public int timeToEnd;

    public int points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;
    private bool isFreezed = false;

    bool gamePaused = false;
    bool endGame = false;
    bool win = false;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI crystals;
    [SerializeField] TextMeshProUGUI GoldKeyText;
    [SerializeField] TextMeshProUGUI GreenKeyText;
    [SerializeField] TextMeshProUGUI RedKeyText;
    [SerializeField] Image freezeImage;


    void Awake()
    {
        if (Instantion == null)
        {
            Instantion = this;
        }
    }
    void Start()
    {

        InvokeRepeating("Stopper", 2, 1);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        PickUpCheck();
    }

    void Stopper()
    {
        freezeImage.enabled = false;
        timeToEnd--;

        int minutes = timeToEnd / 60;
        int seconds = timeToEnd % 60;
        
        timerText.text = minutes + ":" + seconds;

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("You Win!!! Reload?");
        } else
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }

    public void AddPoints(int point)
    {
        points += point;
        crystals.text = points.ToString();
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }
    public void FreezTime(int freez)
    {
        CancelInvoke("Stopper");
        freezeImage.enabled = true;
        InvokeRepeating("Stopper", freez, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Gold)
        {
            goldKey++;
            GoldKeyText.text = goldKey.ToString();
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
            GreenKeyText.text = greenKey.ToString();
        }
        else if (color == KeyColor.Red)
        {
            redKey++;
            RedKeyText.text = redKey.ToString();
        }
    }

    void PickUpCheck()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red: " + redKey + " green: " + greenKey + " gold: " + goldKey);
            Debug.Log("Points: " + points);
        }
    }
}
