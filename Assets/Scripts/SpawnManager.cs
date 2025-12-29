using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] ghosts;
    [SerializeField] private float minimumTimeBetweenSpawn;
    [SerializeField] private float maximumTimeBetweenSpawn;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private float spawnTime;
    [SerializeField] private bool spawnerDone;
    [SerializeField] private TextMeshProUGUI timerText;
    GameObject currentPoint;
    int index;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        starter();
    }

    void spawnGhost()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float spawnTime = Random.Range(minimumTimeBetweenSpawn, maximumTimeBetweenSpawn);

        if(canSpawn)
        {
            Instantiate(ghosts[Random.Range(0, ghosts.Length)], currentPoint.transform.position, Quaternion.identity);
        }   

        Invoke("spawnGhost", spawnTime);
    }

    public void starter()
    {
        spawnTime = 120;
        canSpawn = true;
        StartCoroutine(IncreaseDifficulty());
        Invoke("spawnGhost", 1f);
    }

    void Update()
    {
        if(gameManager.isPlaying)
        {
            canSpawn = true;
        if(canSpawn)
        {
            timerText.text = $"{(int)spawnTime}";
            spawnTime -= Time.deltaTime;
            if(spawnTime <= 0)
            {
                gameManager.isPlaying = false;
            }
        }
        }
        else
        {
            canSpawn = false;
        }
    }

    IEnumerator IncreaseDifficulty()
    {
        yield return new WaitForSeconds(15f);
        minimumTimeBetweenSpawn = 1.95f;
        maximumTimeBetweenSpawn = 5f;
        Debug.Log("increased difficulty 2");
        yield return new WaitForSeconds(20f);
        minimumTimeBetweenSpawn = 1.8f;
        maximumTimeBetweenSpawn = 5f;
        Debug.Log("increased difficulty 2");
        yield return new WaitForSeconds(20f);
        minimumTimeBetweenSpawn = 1.75f;
        maximumTimeBetweenSpawn = 5f;
        Debug.Log("increased difficulty 3");
        // yield return new WaitForSeconds(20f);
        // minimumTimeBetweenSpawn = 1.75f;
        // maximumTimeBetweenSpawn = 4.5f;
        // Debug.Log("increased difficulty 4");
        // yield return new WaitForSeconds(20f);
        // minimumTimeBetweenSpawn = 1.66f;
        // maximumTimeBetweenSpawn = 4f;
        // Debug.Log("increased difficulty 5");
        // yield return new WaitForSeconds(20f);
        // minimumTimeBetweenSpawn = 1.5f;
        // maximumTimeBetweenSpawn = 4f;
    }

    //Code Appropiatied from https://ldjam.com/events/ludum-dare/46/slimekeep
}

