using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

/// <summary>
/// Class responsible for keeping track of the time left in the current level 
/// </summary>
public class Timer : MonoBehaviour
{

    private Text timerText;
    
    private float timer;
    
    /// <summary>
    /// Gets reference to timerText object
    /// </summary>
    void Start()
    {

        timer = GameManager.Instance.currentLevelTime;
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        if (timerObject != null)
        {
            timerText = timerObject.GetComponent<Text>();
        }
        
        
    }
    /// <summary>
    /// updates the timer value and updates the timerText text
    /// if timer runs out, makes a call to GameManager to update the level
    /// </summary>
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

