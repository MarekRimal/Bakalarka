using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredBall : MonoBehaviour {

    Color color;

    public static int BallsInTheGame = 0;

    void Start()
    {
        color = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    // If ball hits other ball of the same color it destroys them
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<ColoredBall>() != null)
        {
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color == color)
            {
                BallsInTheGame -= 2;

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
