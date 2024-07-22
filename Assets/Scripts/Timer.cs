using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Linq.Expressions;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    float currentTime;
    public float defaultTime;

    public Button attackButton;
    public Button magicButton;
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
        StopAllCoroutines(); //Stops the timer
        StartCoroutine(TimerChange()); //Resets the timer to 5 and switches turns

        {
            if (turnCount % 2 == 0) //Player's turn
            {
                attackButton.interactable = true;
                magicButton.interactable = true;
                turnLabel.text = "Player's turn!";
            }
            else //Enemy's turn
            {
                attackButton.interactable = false;
                magicButton.interactable = false;
                turnLabel.text = "Enemy's turn!";
            }
        }
    }
}
