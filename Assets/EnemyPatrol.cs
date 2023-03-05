using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;

    private Transform target;
    private int destPoint;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        // Si ennemi est quasi arrivé à destination
        if(Vector3.Distance(transform.position,target.position) <  0.3f){
            destPoint = (destPoint +1) % waypoints.Length;
            target = waypoints[destPoint];
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(Inventory.instance.getSword()){
                Destroy(gameObject);
            }else{
                if(SceneManager.GetActiveScene().name == "Niveau0"){
                    collision.gameObject.transform.position = new Vector3(-9.17f,3.62f,-10f);
                }
            }
        }
    }

}
