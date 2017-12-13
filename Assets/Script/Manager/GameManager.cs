using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public float secondsForHalf;
    public bool isStart;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        isStart = true;
        secondsForHalf = 60f;
    }
}
