using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Creates a ball every few seconds
public class BallMaker : MonoBehaviour {

    [Header("Prefabs")]
    public GameObject ball;
    public Transform ballSpawn;

    [Header("Game")]
    public float spawnInterval = 3f;
    public float spawnSpeedUpMultiplier = 0.95f;
    float nextSpawnTime;

    int score = 0;
    public int loseTreshold = 50;

    //public float ballLifetime = 10;
    public float force = 3;

    public bool play = false;   // Whether launch balls

    [Header("UI")]
    public Text scoreUI;
    public Text ballCounterUI;
    public Text gameOverUI;

    int[] randomColorsIdxs;
    int nextBallColorIdx = 0;
    public GameObject[] upcomingBalls;
    public GameObject[] ballsCounter;

    public Color[] colors;

    private void Start()
    {

        nextSpawnTime = Time.time;

        foreach (GameObject ball in ballsCounter)
        {
            ball.SetActive(false);
        }

        // Generates random number sequence
        randomColorsIdxs = new int[100];
        for (int i=0; i<100; i++)
        {
            randomColorsIdxs[i] = Random.Range(0, colors.Length-1);
        }

        // Initialize ball colors
        upcomingBalls[0].GetComponent<MeshRenderer>().material.color = colors[randomColorsIdxs[0]];
        upcomingBalls[1].GetComponent<MeshRenderer>().material.color = colors[randomColorsIdxs[1]];
        upcomingBalls[2].GetComponent<MeshRenderer>().material.color = colors[randomColorsIdxs[2]];

        //gameOverUI.enabled = false;
    }

    // Update is called once per frame
    void Update () {

        scoreUI.text = "Score: " + score.ToString();
        ballCounterUI.text = "BallCount: " + ColoredBall.BallsInTheGame.ToString();

        if (play)
        {
            if (Time.time > nextSpawnTime)
            {
                GameObject b = Instantiate(ball, ballSpawn.position, ballSpawn.rotation);
                b.GetComponent<Rigidbody>().AddForce((ballSpawn.forward).normalized * force, ForceMode.Impulse);
                b.GetComponent<MeshRenderer>().material.color = colors[randomColorsIdxs[nextBallColorIdx % randomColorsIdxs.Length]];
                nextBallColorIdx++;

                // Now update ball colors
                upcomingBalls[0].GetComponent<MeshRenderer>().material.color = upcomingBalls[1].GetComponent<MeshRenderer>().material.color;
                upcomingBalls[1].GetComponent<MeshRenderer>().material.color = upcomingBalls[2].GetComponent<MeshRenderer>().material.color;
                upcomingBalls[2].GetComponent<MeshRenderer>().material.color = colors[randomColorsIdxs[nextBallColorIdx+2 % randomColorsIdxs.Length]];

                //Destroy(b, ballLifetime);

                score++;
                ColoredBall.BallsInTheGame++;

                if (ColoredBall.BallsInTheGame%10 == 0)
                {
                    ballsCounter[(ColoredBall.BallsInTheGame / 10)-1].SetActive(true);  // SetActve next one
                }
                if (ColoredBall.BallsInTheGame >= loseTreshold)
                {
                    gameOverUI.enabled = true;
                }

                nextSpawnTime = Time.time + spawnInterval;

                // SpeedUp
                if (spawnInterval >= 0.8)
                {
                    spawnInterval *= spawnSpeedUpMultiplier;
                }
            }
        }
	}
}
