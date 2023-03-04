using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneToLoad;// Cursor.visible = false;
    public int numOfNextLevel;
    public bool isCurrentLevelBroken;
    private static bool[] hasBroken = {false, false, false}; // correspondant au niveau 1, 2 et 3

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Cursor.visible = false;

            // Check if the level is broken
            if (isCurrentLevelBroken) {
                hasBroken[numOfNextLevel-1] = true;
            }

            // load the correct level
            if (numOfNextLevel==4) {
                if (everythingIsBroken()) {
                    Cursor.visible = true;
                    SceneManager.LoadScene(sceneToLoad);
                } else {
                    string newSceneName = "Niveau1";
                    SceneManager.LoadScene(newSceneName);
                }
            }
            else if (!hasBroken[numOfNextLevel-1]) {
                SceneManager.LoadScene(sceneToLoad);
            } else {
                string newSceneName = sceneToLoad + "_cassé";
                SceneManager.LoadScene(newSceneName);
            }
        }
    }

    private bool everythingIsBroken() {
        return (hasBroken[0] && hasBroken[1] && hasBroken[2]);
    }

}