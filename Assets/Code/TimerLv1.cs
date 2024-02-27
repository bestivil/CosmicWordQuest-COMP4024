using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

public class TimerLv1 : MonoBehaviour
{

    private Text timerText;
    private Text levelText; 
    private float timer;
    

    

    void Start()
    {

        timer = GameManager.Instance.currentLevelTime;
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        GameObject levelObject = GameObject.FindGameObjectWithTag("CurrentLevel");
        if (timerObject != null)
        {
            timerText = timerObject.GetComponent<Text>();
        }
        if (levelObject != null)
        {
            levelText = levelObject.GetComponent<Text>();
            levelText.text = "Level: " + GameManager.Instance.level;
        } 
        
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; 
            timerText.text = "Time Left: " + timer.ToString("F0"); 
            
        }
        else
        {
            
            if (timer != -1) 
            {
                GameManager.Instance.LevelCompleted();
                timer = -1; 
                
            }
        }
    }}

