using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float currentTime;
    public float defaultTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }

    public IEnumerator timer()
    {
        resetTimer();
        while (true)
        {
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f); //Can change to whatever interval I want
            currentTime--; //Can change to currentTime = currentTime - interval
            if(currentTime <= 0)
            {
                newFunctionToCall();
            }
        }
    }

    public void resetTimer()
    {
        currentTime = defaultTime;
    }

    public void newFunctionToCall()
    {
        Debug.Log("Something happens!");
        resetTimer();
    }
}
