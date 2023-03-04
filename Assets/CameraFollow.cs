using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float timeOffSet;
    public Vector3 posOffSet;
    private Vector3 velocity;

    private GameObject instance;

    void Start(){
        instance = Instantiate(player, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, instance.transform.position + posOffSet, ref velocity, timeOffSet);
    }
}
