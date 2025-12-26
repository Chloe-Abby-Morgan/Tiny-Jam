using System.Collections;
using UnityEngine;

public class Vaccum : MonoBehaviour
{
    [SerializeField] private float captureTime = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ghost")
        {
            StartCoroutine(Capture(other.gameObject.GetComponent<Ghost>().colour));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ghost")
        {
            StopCoroutine(Capture(other.gameObject.GetComponent<Ghost>().colour));
        }
    }
    IEnumerator Capture(string colour)
    {
        yield return new WaitForSeconds(captureTime);
        Debug.Log(colour);
    }
}
