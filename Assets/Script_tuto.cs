using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_tuto : MonoBehaviour
{
    public string message;

    void Start()
    {
        message = "";
    }


    
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject [] panneaux = GameObject.FindGameObjectsWithTag("Panneau");
        message="";
        foreach(GameObject panneau in panneaux){
            float dist = calculDist(panneau,player);
            if(dist<1){
                message = "Conseil";
                switch(panneau.name) 
                {
                case "panneaux_0":
                    message="Il faut sauter par dessus le trou \npour ne pas mourir (touche ESPACE)";
                    break;
                case "panneaux_1":
                    message="Il faut récupérer l'épée pour tuer le slime. \nMarchez juste dessus.";
                    break;
                default:
                    message="Il faut toucher le drapeau \npour finir le niveau.";
                    break;
                }
            }
        }
    }

    private float calculDist(GameObject object1, GameObject object2){
        Vector2 Pos1 = object1.transform.position;
        Vector2 Pos2 = object2.transform.position;
        float x1 = Pos1.x, x2 = Pos2.x, y1 = Pos1.y, y2 = Pos2.y;
        // Distance between X coordinates
        float xDif = Mathf.Abs((Mathf.Max(x1,x2) - Mathf.Min(x1,x2)));
        // Distance between Y coordinates
        float yDif = Mathf.Abs((Mathf.Max(y1,y2) - Mathf.Min(y1,y2)));
        // Pythagorean theorem
        float finalDistance = Mathf.Sqrt(xDif * xDif + yDif * yDif);
        return finalDistance;
    }

    void OnGUI()
    {
        if(message.Length!=0) {
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 30;
            // Make a label that uses the "box" GUIStyle.
            int rectWidth = 600;
            int rectHeight = 200;
            float halfWidth = (Screen.width-rectWidth)/2;
            GUI.Label (new Rect(halfWidth,0,rectWidth,rectHeight), message, "button");
        }
    }
}
