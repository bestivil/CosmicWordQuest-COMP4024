using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void OnClick(){
        SceneManager.LoadScene("StartScreen");
    }
}

