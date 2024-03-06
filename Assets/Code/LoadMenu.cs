using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    /// <summary>
    /// goes back to StartScreen and resets the player score
    /// </summary>
    public void OnClick(){
        //make sure the scores are reset
        GameManager.Instance.scoreUser = "0";
        GameManager.Instance.liveScore = 0;
        SceneManager.LoadScene("StartScreen");
    }
}


