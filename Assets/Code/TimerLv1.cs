using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

public class TimerLv1 : MonoBehaviour
{

    private Text timerText;
    private Text scoreText; 
    private float timer = 10f; 

    private GameObject usernameDialogObject;

    

    void Start()
    {

        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");
        GameObject scoreObject = GameObject.FindGameObjectWithTag("ScoreText");
        usernameDialogObject = GameObject.FindGameObjectWithTag("UsernameInput");
        if (timerObject != null)
        {
            timerText = timerObject.GetComponent<Text>();
            scoreText = scoreObject.GetComponent<Text>();
            CanvasGroup canvasGroup = usernameDialogObject.GetComponent<CanvasGroup>(); // hiding the username dialog

            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0; 
                canvasGroup.interactable = false; 
                canvasGroup.blocksRaycasts = false;
            }

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
            
            if (timer != -1) 
            {
                Debug.Log("Time's up! Final Score: " + scoreText.text);

                CanvasGroup canvasGroup = usernameDialogObject.GetComponent<CanvasGroup>(); //showing the username dialog, once the timer is up
                if (canvasGroup != null)
                {
                    canvasGroup.alpha = 1;
                    canvasGroup.interactable = true; 
                    canvasGroup.blocksRaycasts = true; 
                }




                timer = -1; 
                
            }
        }
    }}

