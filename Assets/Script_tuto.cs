using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_tuto : MonoBehaviour
{
    public GameObject textObject;

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
    
    void Update()
    {
        
    }
}
