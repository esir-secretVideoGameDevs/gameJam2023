using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool hasSword = false;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    public void setSword(bool sword)
    {
        hasSword = sword;
    }

    public bool getSword()
    {
        return hasSword;
    }

}
