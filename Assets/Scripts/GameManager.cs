using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlaying=true;
    public int roundsWon=0;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameMenu;
    private bool pLock = true;
    private bool sLock = true;
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
                Debug.Log("You win gaymer");
                if(pLock)
                {
                roundsWon++;
                pLock = false;
                }
            }

            if(sLock)
            {
                mainMenu.SetActive(true);
                gameMenu.SetActive(false);
                sLock = false;
            }
        }
        else
        {
             pLock = true;
             sLock = true;
        }
    }

    public void changeState()
    {
        isPlaying = !isPlaying;
    }
}
