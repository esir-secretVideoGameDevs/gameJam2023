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
        
    }
}
