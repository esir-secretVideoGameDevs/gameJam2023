using UnityEngine;

public class getSword : MonoBehaviour {

    public GameObject flag;

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.CompareTag("Player")){
            Destroy(gameObject);
            Inventory.instance.setSword(true);
            flag.GetComponent<LoadSpecificScene>().isCurrentLevelBroken = false;
        }

    }

}
