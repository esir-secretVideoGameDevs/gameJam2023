using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Player")){
            SceneManager.LoadScene("Niveau1");
        }

    }

}
