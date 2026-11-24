using UnityEngine;

public class BasketLogic : MonoBehaviour
{
    float moveSpeed = 5f;
    private Rigidbody2D rb;
    public KeyCode leftPrimary, leftSecondary, rightPrimary, rightSecondary;

    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referencing the rigidbody attached to the basket
        rb = GetComponent<Rigidbody2D>();
        //Gets the GameManager script from first object in heirarchy with the gamecontroller tag.
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = 0f;

        if(Input.GetKey(leftPrimary) || Input.GetKey(leftSecondary))
        {
            moveInput = -1f;
        }
        else if(Input.GetKey(rightPrimary) || Input.GetKey(rightSecondary))
        {
            moveInput = 1f;
        }

        Vector2 newVelocity = new Vector2(moveInput * moveSpeed, rb.angularVelocity);
        rb.linearVelocity = newVelocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Eggs")
        {
            Debug.Log("I have hit an egg.");

            gameManager.score += collision.GetComponent<EggLogic>().score;
            Destroy(collision.gameObject);
        }
    }
}
