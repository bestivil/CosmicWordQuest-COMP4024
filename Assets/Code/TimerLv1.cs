using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

public class TimerLv1 : MonoBehaviour
{

    private Text timerText; // Changed to private since we'll find it by tag
    private Text scoreText; // Changed to private since we'll find it by tag
    private float timer = 10f; // Start a 10-second countdown timer

    void Start()
    {

        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        GameObject scoreObject = GameObject.FindGameObjectWithTag("ScoreText");
        if (timerObject != null)
        {
            timerText = timerObject.GetComponent<Text>();
            scoreText = scoreObject.GetComponent<Text>();
        }
        else
        {
            Debug.LogError("No game object with tag 'ScoreText' found.");
        }
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; 
            timerText.text = "Time: " + timer.ToString("F0"); 
            
        }
        else
        {
            // Ensure this block only runs once when the timer first reaches 0
            if (timer != -1) // Check if the timer has already been set to -1 to avoid repeating this block
            {
                Debug.Log("Time's up! Final Score: " + scoreText.text);
                timer = -1; // Set timer to -1 to indicate the time's up action has been taken
                // Perform any other actions you want when the timer hits 0
            }
        }
    }}

