using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boss_kill : MonoBehaviour
{

    public KeyCode touche ;
    // Start is called before the first frame update
   

    
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(touche)) {
            Debug.Log("la touche et touché");
        }*/
    }
  
    void OnMouseDown() {
        Debug.Log("la touche et touché");
        SceneManager.LoadScene("Main Menu");
    }
}
   /* public keyCode touche ;
    // Start is called before the first frame update
   

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(touche)) {
            Debug.Log("la touche et touché");
        }
    }*/