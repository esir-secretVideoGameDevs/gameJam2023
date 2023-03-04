using UnityEngine;

public class ReturnAtStart : MonoBehaviour
{

    public GameObject camera_;

    private Vector3 positionCameraAtStart;

    void Start(){
        positionCameraAtStart = camera_.transform.position;
    }
    
    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Player")){
            collision.gameObject.transform.position = positionCameraAtStart;
        }

    }

}
