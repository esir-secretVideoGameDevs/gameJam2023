using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource.clip = playlist[0];
        audiosource.Play();   
    }

    // Update is called once per frame
    void Update()
    {
        if(!audiosource.isPlaying){
            audiosource.clip = playlist[0];
        }
    }
}
