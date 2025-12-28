using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float hurtTime = 2f;
    [SerializeField] private GameObject vaccumObject;
    [SerializeField] private GameObject hurtSFX;
    [SerializeField] private Rigidbody2D vaccumRb;
    [SerializeField] private GameObject vaccumSprite;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Sprite hurtSprite;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private GameObject vaccumAppareil;
    [SerializeField] private AudioSource empty;
    public bool isHurt = false;
    private float moveInput;
    private CollectionManager collectionManager;
    private GameObject[] ghosts;
    private bool hurting = false;
    private bool facingLeft = false;
    private bool sLock=true;
    Vector2 movement;
    Vector2 mousePosition;
    GameManager gameManager;

    void Awake()
    {
        collectionManager = GameObject.Find("CollectionManager").GetComponent<CollectionManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManager.isPlaying)
        {
        if(!isHurt)
        {
            vaccumAppareil.SetActive(true);
            if(Input.GetButton("Fire1") && collectionManager.collected[^1] == "")
            {
                vaccumSprite.SetActive(true);
            }
            else if(Input.GetButton("Fire1") && collectionManager.collected[^1] != "" && sLock)
            {
                sLock = false;
                empty.PlayOneShot(empty.clip);         
            }
            else
            {
                vaccumSprite.SetActive(false);
            }

            if(Input.GetButtonUp("Fire1"))
                {
                    sLock = true;
                }

            if(Input.GetKeyDown(KeyCode.R))
            {
                for(int i = 0; i < collectionManager.collected.Length; i++)
                    {
                        collectionManager.collected[i] = "";
                        collectionManager.collectedImageObj[i].sprite = null;
                        collectionManager.imageObj[i].SetActive(false);
                        collectionManager.correct[i] = false;
                    }
                empty.PlayOneShot(empty.clip);
            }
            
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 lookDirection = mousePosition - vaccumRb.position;
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

                moveInput = Input.GetAxis("Horizontal");


                if(facingLeft && mousePosition.x > 0)
                {
                    Fliper();
                }
                else if(!facingLeft && mousePosition.x< 0)
                {
                    Fliper();
                }

                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                vaccumRb.transform.position = rb.position;
                vaccumRb.rotation = angle;
        }
        else
        {
            if(!hurting)
            {
            hurting = !hurting;
            StartCoroutine(Damage());
            }
        }

        ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        }
    }

    IEnumerator Damage()
    {
        Debug.Log("Owwwww");
        hurtSFX.SetActive(true);
        vaccumAppareil.SetActive(false);
        playerSprite.sprite = hurtSprite;
        vaccumSprite.SetActive(false);
        for(int i = 0; i < collectionManager.collected.Length; i++)
        {
            collectionManager.collected[i] = "";
            collectionManager.collectedImageObj[i].sprite = null;
            collectionManager.imageObj[i].SetActive(false);
            collectionManager.correct[i] = false;
        }

        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Ghost>().die();
        }
        yield return new WaitForSeconds(hurtTime);
        isHurt = !isHurt;
        hurting = !hurting;
        playerSprite.sprite = idleSprite;
        vaccumAppareil.SetActive(true);
        hurtSFX.SetActive(false);
    }

    void Fliper()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
