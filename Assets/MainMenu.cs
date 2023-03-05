using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private string sceneName = "Niveau0";

    public void StartGame(){
        LoadSpecificScene.resetGame();
        SceneManager.LoadScene(sceneName);
    }

    public void Settings(){
        
    }

    public void Credits(){
        SceneManager.LoadScene("Credit");
    }

    public void QuitCredits(){
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit(){
        Application.Quit();
    }

}
