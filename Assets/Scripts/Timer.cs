using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    PLayer_Controller playerAnimator;
    public bool isDead;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 60f;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.color = Color.red;
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("Game Over Tela");
    }
}
