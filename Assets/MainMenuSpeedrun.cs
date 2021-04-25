using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuSpeedrun : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerTMP;
    private static string KEY = "SpeedrunTime";
    void Start()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            var totalTime = PlayerPrefs.GetFloat(KEY);
            float minutes = (totalTime / 60);
            float seconds = (totalTime % 60);
            timerTMP.text = "Best time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
