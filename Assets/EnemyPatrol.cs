using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
