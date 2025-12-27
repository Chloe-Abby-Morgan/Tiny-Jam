using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
   public string[] collected;
   public Image[] collectedImageObj;
   public GameObject[] imageObj;
   public Sprite[] sourceImages;
   public bool[] correct;
   public int correctCount;
   public string[] targets;
   [SerializeField] private Image[] requiredObj;

    void Start()
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

        }
    }

    public void redo()
    {
        for(int i = 0; i < targets.Length; i++)
        {
            collected[i] = "";
            correct[i] = false;
            imageObj[i].SetActive(false);
        }

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
}
