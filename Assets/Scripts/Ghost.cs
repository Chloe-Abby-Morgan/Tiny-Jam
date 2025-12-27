using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private SpriteRenderer ghostSprite;
    private GameObject player;
    public string colour = "green";
    GameManager gameManager;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ghostSprite = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManager.isPlaying == false)
        {
            Destroy(gameObject);
        }

        Vector2 direction = (player.transform.position - transform.position).normalized;
        ghostSprite.flipX = direction.x < 0;
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
