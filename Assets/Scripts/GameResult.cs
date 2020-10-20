using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public bool result;
    public float spentTime;
    public Victorina victorina;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        result = victorina.gameResult;
        spentTime = victorina.timerForResultForGameEnd;
    }
}
