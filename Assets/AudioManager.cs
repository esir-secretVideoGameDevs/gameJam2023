using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource.clip = playlist[0];
        audiosource.loop =true;
        audiosource.Play();
    }

    private Scene sceneCourante;
    void Awake()
    {
        GameObject[] musObjs = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       //TODO: tentative de régler le problème des l'absence de musique lorsque l'on veut rejouer (génère erreur actuellement)
       // if(audiosource==null)audiosource= new AudioSource();
        string name = scene.name;
        string courantename = (sceneCourante.name==null)?"":sceneCourante.name;
        if(!name.Contains("Niveau")){
            audiosource.Stop();
        }
        else if(name.Equals("Niveau4_cassé")){
            audiosource.clip=playlist[2];
            audiosource.Play();
        }
        else if(!name.Equals(courantename) && (name.EndsWith("_cassé")!=courantename.EndsWith("_cassé")) && name.EndsWith("_cassé")){
            audiosource.clip=playlist[1];
            audiosource.Play();
        }
        else if(!audiosource.isPlaying && name.Equals("Niveau0")){
            audiosource.clip = playlist[0];
            audiosource.loop =true;
            audiosource.Play();
        }
        sceneCourante = scene;
    }

    

    

}
