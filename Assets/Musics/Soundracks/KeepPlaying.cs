using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlaying : MonoBehaviour
{
    void Awake()
    {
        GameObject [] musObjs = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musObjs.Length>1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
