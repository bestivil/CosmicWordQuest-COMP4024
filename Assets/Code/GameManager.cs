using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int level = 1;
    public float currentLevelTime = 10f; // Default timing for the level
    private GameObject usernameDialogObject;

    private string nameUser;
    public string scoreUser = "0";
    

    void Awake()
    {
        
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make sure the GameManager persists across scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Ensure there is only one GameManager
        }

        
    }

    void addDatabase()
    {
        // Add the user's name and score to the database
    }

    public void setNames(string name)
    {
        nameUser = name;
        
    }

    public void LevelCompleted()
    {
        level++;

        if (level >= 3)
        {
            GameObject scoreTextObject = GameObject.FindGameObjectWithTag("ScoreText");
            if (scoreTextObject != null)
            {
                scoreUser = scoreTextObject.GetComponent<Text>().text;
            }

            FinalScoreDialog();
        }
        else
        {
            AdjustLevelTiming();
            LoadCurrentScene();
        }

        
    }

    

    void AdjustLevelTiming()
    {
        
        currentLevelTime = Mathf.Max(5, currentLevelTime - 3);
    }

    void LoadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void FinalScoreDialog()
    {
       
        SceneManager.LoadScene("HighScoreScreen");
    }

    public void LoadLeaderboard()
    {
        
        SceneManager.LoadScene("Leaderboard");
        
    }
}
