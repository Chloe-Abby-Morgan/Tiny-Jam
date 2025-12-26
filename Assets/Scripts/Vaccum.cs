using UnityEngine;

public class Vaccum : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ghost")
        {
            Debug.Log("other");
        }
    }
}
