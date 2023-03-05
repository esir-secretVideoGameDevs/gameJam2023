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
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audiosource.isPlaying)
        {
            audiosource.clip = playlist[0];
        }
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
        bool casse = scene.name.EndsWith("_cassé");
        bool casseCourante = (sceneCourante.name==null)?false:sceneCourante.name.EndsWith("_cassé");
        if(casse!=casseCourante){
         audiosource.Stop();   
        }
        //Debug.Log(changementcontexte);
        // bool  scasee =  cassee(scene);
        // if (cassee(sceneCourante) !=scasee)
        // {
        //     // Il faut changer 
        //     audiosource.Stop();
        //     int indiceMusique = scasee?1:0;
        //     audiosource.clip = playlist[indiceMusique];
        // }
        // sceneCourante =scene;
    }

}
