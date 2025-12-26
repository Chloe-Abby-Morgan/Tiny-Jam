using System.Collections;
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
    [SerializeField] private Rigidbody2D vaccumRb;
    [SerializeField] private GameObject vaccumSprite;
    public bool isHurt = false;
    private float moveInput;
    private CollectionManager collectionManager;
    private GameObject[] ghosts;
    Vector2 movement;
    Vector2 mousePosition;

    void Awake()
    {
        collectionManager = GameObject.Find("CollectionManager").GetComponent<CollectionManager>();
    }

    void Update()
    {
        if(!isHurt)
        {
            if(Input.GetButton("Fire1"))
            {
                vaccumSprite.SetActive(true);
            }
            
            else
            {
                vaccumSprite.SetActive(false);
            }
            
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 lookDirection = mousePosition - vaccumRb.position;
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

                moveInput = Input.GetAxis("Horizontal");

                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                vaccumRb.MovePosition(vaccumRb.position + movement * moveSpeed * Time.fixedDeltaTime);
                vaccumRb.rotation = angle;
        }
        else
        {
            StartCoroutine(Damage());
        }

        ghosts = GameObject.FindGameObjectsWithTag("Ghost");
    }

    IEnumerator Damage()
    {
        Debug.Log("Owwwww");
        for(int i = 0; i < collectionManager.collected.Length; i++)
        {
            collectionManager.collected[i] = "";
        }

        foreach(GameObject ghost in ghosts)
        {
            Destroy(ghost);
        }
        yield return new WaitForSeconds(hurtTime);
        isHurt = !isHurt;
    }
}
