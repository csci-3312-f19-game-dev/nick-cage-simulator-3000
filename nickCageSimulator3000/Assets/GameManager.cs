using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float startTime;
    int day;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        startTime = Time.time;
        day = 1;
    }

    void Update()
    {
        if((Time.time - startTime) % 100 > day)
        {
            day++;
        }
    }
}
