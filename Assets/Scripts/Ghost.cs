using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private GameObject player;
    public string colour = "green";

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().isHurt = true;
            Destroy(gameObject);
        }
    }
}
