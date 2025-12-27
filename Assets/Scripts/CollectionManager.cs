using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
   public string[] collected;
   public Image[] collectedImageObj;
   public GameObject[] imageObj;
   public Sprite[] sourceImages;
   public bool[] correct;
   [SerializeField] private string[] targets;
   [SerializeField] private Image[] requiredObj;
   private int correctCount;
   private bool isPlaying = false;

    void Awake()
    {
        for(int i = 0; i < targets.Length; i++)
        {
            if(Random.Range(0, targets.Length) == 0)
            {
                targets[i] = "red";
                requiredObj[i].sprite = sourceImages[0];
            }
            else if(Random.Range(0, targets.Length) == 1)
            {
                targets[i] = "green";
                requiredObj[i].sprite = sourceImages[1];
            }
            else
            {
                targets[i] = "blue";
                requiredObj[i].sprite = sourceImages[2];
            }
        }
    }

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
