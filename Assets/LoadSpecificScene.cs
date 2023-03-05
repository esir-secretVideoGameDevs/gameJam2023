using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneToLoad;// Cursor.visible = false;
    public int numOfNextLevel;
    public bool isCurrentLevelBroken;
    private static bool[] hasBroken = {false, false, false}; // correspondant au niveau 1, 2 et 3

    private static int numberOfLoop = 0;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Cursor.visible = false;

            // Check if the level is broken
            if (isCurrentLevelBroken) {
                hasBroken[numOfNextLevel-2] = true;
            }

            // load the correct level
            if (numOfNextLevel==4 && everythingIsBroken() && numberOfLoop>0) {
                Cursor.visible = true;
                SceneManager.LoadScene(sceneToLoad);
            } else  {
                if(numOfNextLevel==4) {
                    numOfNextLevel = 1;
                    sceneToLoad = "Niveau1";
                    numberOfLoop++;
                    // Load a dialogue screen (cat & mother)
                }// else {
                    // Load a dialogue screen (cat only)
                    if (!hasBroken[numOfNextLevel-1]) {
                        SceneManager.LoadScene(sceneToLoad);
                    } else {
                        string newSceneName = sceneToLoad + "_cassé";
                        SceneManager.LoadScene(newSceneName);
                    }
                //}
            }
        }
    }

    private bool everythingIsBroken() {
        return (hasBroken[0] && hasBroken[1] && hasBroken[2]);
    }

}