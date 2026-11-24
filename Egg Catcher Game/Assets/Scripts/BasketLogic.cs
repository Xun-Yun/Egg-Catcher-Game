using UnityEngine;

public class BasketLogic : MonoBehaviour
{
    float moveSpeed = 5f;
    private Rigidbody2D rb;

    public KeyCode leftPrimary, leftSecondary, rightPrimary, rightSecondary;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referencing the rigidbody attached to the basket
        rb = GetComponent<Rigidbody2D>();
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
}
