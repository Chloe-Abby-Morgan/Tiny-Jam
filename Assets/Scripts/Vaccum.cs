using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Vaccum : MonoBehaviour
{
    [SerializeField] private float captureTime = 1f;
    private CollectionManager collectionManager;
    private bool capturing = false;

    void Awake()
    {
        collectionManager = GameObject.Find("CollectionManager").GetComponent<CollectionManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ghost")
        {
            if (!capturing)
            {
            StartCoroutine(Capture(other.gameObject.GetComponent<Ghost>().colour, other.gameObject));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ghost")
        {
            capturing = false;
            StopCoroutine(Capture(other.gameObject.GetComponent<Ghost>().colour, other.gameObject));
        }
    }
    IEnumerator Capture(string colour, GameObject ghost)
    {
        capturing = true;
        yield return new WaitForSeconds(captureTime);
        if(collectionManager.collected[^1] == "")
        {
            for(int i = 0; i < collectionManager.collected.Length; i++)
            {
                if(collectionManager.collected[i] == "")
                {
                    collectionManager.collected[i] = colour;
                    Destroy(ghost);
                    break;
                }
            }
        }
    }
}
