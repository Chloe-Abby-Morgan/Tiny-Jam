using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] ghosts;
    [SerializeField] private float minimumTimeBetweenSpawn;
    [SerializeField] private float maximumTimeBetweenSpawn;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private float spawnTime;
    [SerializeField] private int ghostsInRoom;
    [SerializeField] private bool spawnerDone;
    GameObject currentPoint;
    int index;

    void Start()
    {
        StartCoroutine(IncreaseDifficulty());
        Invoke("spawnGhost", 1f);
    }

    void spawnGhost()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float spawnTime = Random.Range(minimumTimeBetweenSpawn, maximumTimeBetweenSpawn);

        if(canSpawn)
        {
            Instantiate(ghosts[Random.Range(0, ghosts.Length)], currentPoint.transform.position, Quaternion.identity);
            ghostsInRoom++;
        }   

        Invoke("spawnGhost", spawnTime);
    }

    void Update()
    {
        if(canSpawn)
        {
            spawnTime -= Time.fixedDeltaTime;
            if(spawnTime <= 0)
            {
                canSpawn = false;
            }
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
        yield return new WaitForSeconds(20f);
        minimumTimeBetweenSpawn = 1.75f;
        maximumTimeBetweenSpawn = 4.5f;
        Debug.Log("increased difficulty 4");
        yield return new WaitForSeconds(20f);
        minimumTimeBetweenSpawn = 1.66f;
        maximumTimeBetweenSpawn = 4f;
        Debug.Log("increased difficulty 5");
        yield return new WaitForSeconds(20f);
        minimumTimeBetweenSpawn = 1.5f;
        maximumTimeBetweenSpawn = 4f;
    }

    //Code Appropiatied from https://ldjam.com/events/ludum-dare/46/slimekeep
}

