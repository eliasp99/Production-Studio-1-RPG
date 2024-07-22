using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    float currentTime;
    public float defaultTime;

    public Button attackButton;
    public float turnCooldownDuration;
    private float turnCooldownTimer = 0.0f;
    private bool canClickButton = true;
    private int turnCount = 0;
    public TMP_Text turnLabel;
    


    void Start()
    {
        currentTime = defaultTime;
        StartCoroutine(TimerChange());

        attackButton.interactable = true;
    }

    public void OnButtonClick()
    {
        
        if (canClickButton)
        {
            attackButton.interactable = false;
            canClickButton = false;

            turnCooldownTimer = turnCooldownDuration; 
        }
    }

    public IEnumerator TimerChange()
    {
        //SwitchTurns();
        while (true)
        {
            timerText.text = "Time: " + currentTime.ToString();
            yield return new WaitForSeconds(1f); //Can change to whatever interval I want
            currentTime--; //Can change to currentTime = currentTime - interval
            if(currentTime <= 0)
            {
                SwitchTurns();
            }
        }
    }

    void Update()
    {
        if (!canClickButton)
        {
            turnCooldownTimer -= Time.deltaTime;

            if (turnCooldownTimer <= 0.0f)
            {
                attackButton.interactable = true;
                canClickButton = true;
            }
        }
    }

    public void SwitchTurns()
    {
        Debug.Log("Turn switch!");
        turnCount++;
        currentTime = defaultTime;
        StopAllCoroutines();
        StartCoroutine(TimerChange());

        {
            if (turnCount % 2 == 0)
            {
                attackButton.interactable = true;
                turnLabel.text = "Player's turn!";
            }
            else
            {
                attackButton.interactable = false;
                turnLabel.text = "Enemy's turn!";
            }
        }
    }
}
