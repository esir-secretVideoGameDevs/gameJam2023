using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_tuto : MonoBehaviour
{
    public GameObject textObject;

    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Player")){
            textObject.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision){

        textObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject [] panneaux = GameObject.FindGameObjectsWithTag("Panneau");
        foreach(GameObject panneau in panneaux){
            float dist = calculDist(panneau,player);
            Debug.Log(panneau.name+" "+ dist);
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
}
