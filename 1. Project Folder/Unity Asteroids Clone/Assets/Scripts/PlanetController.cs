using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public static int Lives;
    public int startLives = 100;

    public static int Rounds;

    public static int ShotsRemaining;
    public int startShots = 3;
    // Start is called before the first frame update
    void Start()
    {
        Lives = startLives;

        Rounds = 0;

        ShotsRemaining = startShots;
    }
}
