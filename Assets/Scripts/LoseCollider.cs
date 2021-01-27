using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // cached reference
    GameSession myGameSession;
    Ball myBall;

    private void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
    }


    private void OnTriggerEnter2D(Collider2D collision )
    {
        myGameSession.DecLives();
        myBall.ResetBallOnPaddle();
        if (myGameSession.currentLives <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
