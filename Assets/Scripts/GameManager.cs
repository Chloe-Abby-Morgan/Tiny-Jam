using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPlaying=true;
    CollectionManager collectionManager;

    void Awake()
    {
        collectionManager = GameObject.Find("CollectionManager").GetComponent<CollectionManager>();
    }

    void Update()
    {
        if(!isPlaying)
        {
            for(int i = 0; i < collectionManager.targets.Length; i++)
            {
                if(i == 0)
                {
                    collectionManager.correctCount = 0;
                }

                if(collectionManager.correct[i] == true)
                {
                    collectionManager.correctCount++;
                }
            }

        if(collectionManager.correctCount == collectionManager.correct.Length)
        {
            isPlaying = !isPlaying;
            Debug.Log("You win gaymer");
        }
        
        }
    }
}
