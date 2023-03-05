using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float timeOffSet;
    public Vector3 posOffSet;
    private Vector3 velocity;
    private bool dispMessage = true;

    public static string message = "Default : Hello World!\nAppuyez sur a pour fermer";

    private GameObject instance;


    void Start(){
        // a commenter
        instance = Instantiate(player, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {
        /*if (Input.GetKeyUp("a")) {
            initCaracter();
        }*/
        transform.position = Vector3.SmoothDamp(transform.position, instance.transform.position + posOffSet, ref velocity, timeOffSet);
    }

    /*private void initCaracter() {
        dispMessage = false;
        instance = Instantiate(player, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
    }

    void OnGUI() {
        if(dispMessage) {
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 30;
            // Make a label that uses the "box" GUIStyle.
            int rectWidth = 600;
            int rectHeight = 200;
            float halfWidth = (Screen.width-rectWidth)/2;
            GUI.Label (new Rect(halfWidth,0,rectWidth,rectHeight), message, "button");
        }
    }*/
}
