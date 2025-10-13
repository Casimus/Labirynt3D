using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<int> OnTimeChanged;
    public event Action<int> OnScoreChanged;
    public event Action<Dictionary<KeyColor, int>> OnKeyChanged ;
    public event Action<bool> OnPauseChanged; 
    
    public static GameManager Instantion { get; private set; }
    public int timeToEnd;

    public int points = 0;

    //public int redKey = 0;
    //public int greenKey = 0;
    //public int goldKey = 0;

    public Dictionary<KeyColor, int> keys;

    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    void Awake()
    {
        if (Instantion == null)
        {
            Instantion = this;
        }
    }
    void Start()
    {
        keys = new Dictionary<KeyColor, int>();
        keys.Add(KeyColor.Red, 0);
        keys.Add(KeyColor.Green, 0);
        keys.Add(KeyColor.Gold, 0);
        OnTimeChanged?.Invoke(timeToEnd);
        OnScoreChanged?.Invoke(points);
        OnKeyChanged?.Invoke(keys);
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
        timeToEnd--;
        OnTimeChanged?.Invoke(timeToEnd);
        //Debug.Log("Time: " + timeToEnd + " s");
        
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
        OnPauseChanged?.Invoke(gamePaused);
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
        OnPauseChanged?.Invoke(gamePaused);
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
        OnScoreChanged?.Invoke(points);
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }
    public void FreezTime(int freez)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freez, 1);
    }

    public void AddKey(KeyColor color)
    {
        keys[color]++;
        OnKeyChanged?.Invoke(keys);
    }

    public void UseKey(KeyColor color)
    {
        keys[color]--;
        OnKeyChanged?.Invoke(keys);
    }

    void PickUpCheck()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red: " + keys[KeyColor.Red] + 
                " green: " + keys[KeyColor.Green] + 
                " gold: " + keys[KeyColor.Gold]);
            Debug.Log("Points: " + points);
        }
    }
}
