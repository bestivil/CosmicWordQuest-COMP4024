using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

public class Timer : MonoBehaviour
{

    private Text timerText;
    
    private float timer;
    
    void Start()
    {

        timer = GameManager.Instance.currentLevelTime;
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        if (timerObject != null)
        {
            timerText = timerObject.GetComponent<Text>();
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

