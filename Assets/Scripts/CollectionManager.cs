using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
   public string[] collected;
   public Image[] collectedImageObj;
   public GameObject[] imageObj;
   public Sprite[] sourceImages;
   [SerializeField] private string[] targets;
   [SerializeField] private bool[] correct;
   private int correctCount;
   private bool isPlaying = false;

    void Update()
    {

        for(int i = 0; i < targets.Length; i++)
        {
            if(collected[i] == targets[i])
            {
                correct[i] = true;
            }

            if(i == 0)
            {
                correctCount = 0;
            }

            if(correct[i] == true)
            {
                correctCount++;
            }
        }

        if(correctCount == correct.Length && !isPlaying)
        {
            isPlaying = !isPlaying;
            Debug.Log("You win gaymer");
        }
        
    }
}
