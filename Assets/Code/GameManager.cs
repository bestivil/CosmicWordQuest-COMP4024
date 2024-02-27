using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int level = 1;
    public float currentLevelTime = 10f; // Default timing for the level
    private GameObject usernameDialogObject;
    

    void Awake()
    {
        usernameDialogObject = GameObject.FindGameObjectWithTag("UsernameInput");
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make sure the GameManager persists across scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Ensure there is only one GameManager
        }

        CanvasGroup canvasGroup = usernameDialogObject.GetComponent<CanvasGroup>(); 
        Debug.Log(canvasGroup); 

            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0; 
                canvasGroup.interactable = false; 
                canvasGroup.blocksRaycasts = false;
            }
    }

    public void LevelCompleted()
    {
        level++;

        if (level >= 3)
        {
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
        usernameDialogObject = GameObject.FindGameObjectWithTag("UsernameInput");
        if (usernameDialogObject != null)
        {
        CanvasGroup canvasGroup = usernameDialogObject.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true; 
                canvasGroup.blocksRaycasts = true; 
            }
    }}
}
