using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    private float totalTime = 0;
    [SerializeField]
    private TextMeshProUGUI timerTMP;

    private static string KEY = "SpeedrunTime";
    private bool timerRunning = true;

    private void OnLevelWasLoaded(int level)
    {
        if (level == 13)
        {
            timerRunning = false;
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            HandleSpeedrun();
        }
    }

    private void HandleSpeedrun()
    {
        if (!PlayerPrefs.HasKey(KEY))
        {
            PlayerPrefs.SetFloat(KEY, totalTime);
        }

        if (PlayerPrefs.GetFloat(KEY) > totalTime)
        {
            PlayerPrefs.SetFloat(KEY, totalTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerRunning)
        {
            return;
        }

        totalTime += Time.deltaTime;
        float minutes = (totalTime / 60);
        float seconds = (totalTime % 60);
        timerTMP.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
