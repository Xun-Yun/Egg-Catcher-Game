using UnityEngine;

public class EggLogic : MonoBehaviour
{
    public int score = 0;
    public float rotateSpeed = 0f;
    public float fallSpeed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the egg downwards on the y-axis
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        //Move the egg around its z-axis
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
