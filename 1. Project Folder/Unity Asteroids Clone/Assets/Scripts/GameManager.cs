using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        return;

        /*if (Input.GetKeyDown("e"))
            EndGame();*/ //test cost for game over ui

        if (PlanetController.Lives <= 0)
        {
            EndGame();
        }
    }


    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
