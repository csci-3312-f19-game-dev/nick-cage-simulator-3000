using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Threading;

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

    //Will run independent of everything else... I think?
    IEnumerator UpdateDay()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            day++;
            //Debug.Log("Just added a day");
        }
    }
}