using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private string sceneName = "Niveau0";

    public void StartGame(){
        SceneManager.LoadScene(sceneName);
    }

    public void Settings(){
        
    }

    public void Credits(){
        
    }


    public void Quit(){
        Application.Quit();
    }

}
