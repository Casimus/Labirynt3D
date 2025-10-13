using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI redKeysText;
    [SerializeField] private TextMeshProUGUI greenKeysText;
    [SerializeField] private TextMeshProUGUI goldKeysText;
    [SerializeField] private Image pauseImage;
    private void Start()
    {
        GameManager.Instantion.OnTimeChanged += TimerUpdate;
        GameManager.Instantion.OnScoreChanged += ScoreUpdate;
        GameManager.Instantion.OnKeyChanged += KeysUpdate;
        GameManager.Instantion.OnPauseChanged += PauseGame;
        pauseImage.gameObject.SetActive(false);
    }

    private void PauseGame(bool paused)
    {
        pauseImage.gameObject.SetActive(paused);
    }


    private void KeysUpdate(Dictionary<KeyColor, int> key)
    {
        redKeysText.text = key[KeyColor.Red].ToString();
        greenKeysText.text = key[KeyColor.Green].ToString();
        goldKeysText.text = key[KeyColor.Gold].ToString();
    }

    private void ScoreUpdate(int points)
    {
        pointsText.text = points.ToString();
    }

    private void TimerUpdate(int time)
    {
        // 00:00 

        int minutes = time / 60;
        int seconds = time % 60;
        
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    private void OnDestroy()
    {
        GameManager.Instantion.OnTimeChanged -= TimerUpdate;
        GameManager.Instantion.OnScoreChanged -= ScoreUpdate;
        GameManager.Instantion.OnKeyChanged -= KeysUpdate;
        GameManager.Instantion.OnPauseChanged -= PauseGame;
    }
}
