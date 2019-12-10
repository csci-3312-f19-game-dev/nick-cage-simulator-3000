using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//The purpose of this class is to track time for the day counter on the bottom menu.

public class DayCounter : MonoBehaviour
{
    private int day;
    public Text dayDisplay;//assigned in inspector, so must be public

    void Start()
    {
        day = 0;
        Time.timeScale = 1;
        StartCoroutine("UpdateDay");
    }

    void Update()
    {
        dayDisplay.text = ("Day " + day);
    }

    
    IEnumerator UpdateDay() //Will run independent of everything else
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            day++;
        }
    }
}