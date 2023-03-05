using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneToLoad;// Cursor.visible = false;
    public int numOfNextLevel;
    public bool isCurrentLevelBroken;
    private static bool[] hasBroken = {false, false, false}; // correspondant au niveau 1, 2 et 3

    private static int numberOfLoop = 0;

    public static void resetGame() {
        hasBroken[0] = false;
        hasBroken[1] = false;
        hasBroken[2] = false;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Cursor.visible = false;

            Inventory.instance.setSword(false);

            // Check if the level is broken
            if (isCurrentLevelBroken) {
                hasBroken[numOfNextLevel-2] = true;
            }

            // load the correct level
            if (numOfNextLevel==4 ) {
                numberOfLoop++;
                if (everythingIsBroken() && numberOfLoop>1) {
                    Cursor.visible = true;
                    SceneManager.LoadScene(sceneToLoad+"_cassé");
                } else {
                    SceneManager.LoadScene(sceneToLoad);
                }
            } else  {
                if (!hasBroken[numOfNextLevel-1]) {
                    SceneManager.LoadScene(sceneToLoad);
                } else {
                    string newSceneName = sceneToLoad + "_cassé";
                    SceneManager.LoadScene(newSceneName);
                }
            }
        }
    }

    private bool everythingIsBroken() {
        return (hasBroken[0] && hasBroken[1] && hasBroken[2]);
    }

}