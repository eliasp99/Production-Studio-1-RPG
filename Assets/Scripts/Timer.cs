using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float currentTime;
    public float defaultTime;

    public Button AttackButton;
    public float turnCooldownDuration;
    private float turnCooldownTimer = 0.0f;
    private bool canClickButton = true;
    private int turnCount = 0;
    


    void Start()
    {
        StartCoroutine(timer());

        AttackButton.interactable = true;
    }

    public void OnButtonClick()
    {
        if (canClickButton)
        {
            AttackButton.interactable = false;
            canClickButton = false;

            turnCooldownTimer = turnCooldownDuration;
        }
    }

    public IEnumerator timer()
    {
        SwitchTurns();
        while (true)
        {
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f); //Can change to whatever interval I want
            currentTime--; //Can change to currentTime = currentTime - interval
            if(currentTime <= 0)
            {
                SwitchTurns();
                AttackButton.interactable = false;
                SwitchTurns();
                {
                    turnCount++;
                }

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
                AttackButton.interactable = true;
                canClickButton = true;
            }
        }
    }

    public void SwitchTurns()
    {
        Debug.Log("Turn switch!");
        currentTime = defaultTime;
        {
            if (turnCount % 2 == 0)
            {
                AttackButton.interactable = true;
            }
            else
            {
                AttackButton.interactable = false;
            }
        }
    }

}
