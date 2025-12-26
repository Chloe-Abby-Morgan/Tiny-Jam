using UnityEngine;
using UnityEngine.UIElements;

public class CollectionManager : MonoBehaviour
{
   public string[] collected;
   [SerializeField] private string[] targets;
   [SerializeField] private bool[] correct;

    void Update()
    {
        for(int i = 0; i > targets.Length; i++)
        {
            if(collected[i] == targets[i])
            {
                correct[i] = true;
            }
        }
    }
}
