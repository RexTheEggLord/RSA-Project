using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesDecrese : MonoBehaviour
{
    [SerializeField]private GameObject livesDecreseObject;
    [SerializeField] private GameObject gameOverScreen;

    public void Awake()
    {
        gameOverScreen.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        levelManger.main.lives--;
        Debug.Log("Lives: " + levelManger.main.lives);
        if (levelManger.main.lives <= 15)
        {
            Debug.Log("Game Over!");
            gameOverScreen.SetActive(true);
        }
        
    }
}
