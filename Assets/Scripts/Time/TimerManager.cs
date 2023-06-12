using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float totalTimeInSeconds;   
    
    private float currentTimeInSeconds; 
    private TextMeshProUGUI timerText;
    private ChangeScene changeScene;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        changeScene = GetComponent<ChangeScene>();
        currentTimeInSeconds = totalTimeInSeconds;
    }

    private void Update()
    {
        if (currentTimeInSeconds > 0)
        {
            currentTimeInSeconds -= Time.deltaTime;

            int hours = Mathf.FloorToInt(currentTimeInSeconds / 3600);
            int minutes = Mathf.FloorToInt((currentTimeInSeconds % 3600) / 60);
            int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60);

            string formattedTime = string.Format("{0:00}h{1:00}m{2:00}s", hours, minutes, seconds);
            timerText.text = formattedTime;
        }
        else
        {
           changeScene.ChangeSceneByName("GameOver");
        }
    }
}
