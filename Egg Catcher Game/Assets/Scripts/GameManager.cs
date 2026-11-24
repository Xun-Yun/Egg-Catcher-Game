using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public float endGameTimerMax = 60f;
    public float endGameTimerCurrent;

    public float eggTimerMax = 5f;
    public float eggTimerMin = 2f;
    public float eggTimerCurrent;

    public GameObject[] theEggs;
    private float minX, maxX;
    private float spawnY;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*Calculate the min and max x bounds using the camera.
          These values represent the bottom left and bottom right of the screen.*/
        Vector3 leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));

        //Get the upper bounds of the camera.
        Vector3 topBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        minX = leftBound.x;
        maxX = rightBound.x;
        spawnY = topBound.y;

        eggTimerCurrent = eggTimerMax;
        endGameTimerCurrent = endGameTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        eggTimerCurrent -= Time.deltaTime;
        endGameTimerCurrent -= Time.deltaTime;

        if (eggTimerCurrent <= 0)
        {
            SpawnEgg();
        }

        if(endGameTimerCurrent <= 0)
        {
            
        }
    }
    public void SpawnEgg()
    {
        eggTimerCurrent = Random.Range(eggTimerMin, eggTimerMax);
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

        Instantiate(theEggs[Random.Range(0, theEggs.Length)], spawnPosition, Quaternion.identity);

        scoreText.text = "Score: " + score;
        timerText.text = "Time Remaining: " + endGameTimerCurrent.ToString("F2"); //Converted to string and formatted to 2 decimal places.
    }
}
