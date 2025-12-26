using UnityEngine;

public class Ghost : MonoBehaviour
{
    public string colour = "green";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Vaccum")
        {
            Debug.Log(colour);
        }
    }
}
