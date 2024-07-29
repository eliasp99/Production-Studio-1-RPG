using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Linq.Expressions;
using JetBrains.Annotations;

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
    public bool playerHealth;
    public float minTime = 1.0f;
    public float maxTime = 5.0f;
    public int currentMagic = 0;
    public bool usingMagic = false;
    
    



    void Start()
    {
        currentTime = defaultTime;
        StartCoroutine(TimerChange());
        


        attackButton.interactable = true;

        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Healthbar>();
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

    public IEnumerator RandomTrigger()
    {
        float randomTime = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomTime);
        GameObject otherObject = GameObject.Find("PlayerHealth");

        if (otherObject != null)
        {
            Healthbar Healthbarcomponent = otherObject.GetComponent<Healthbar>();

            if (Healthbarcomponent != null)
            {
                {
                    Healthbarcomponent.TakeDamage(10);
                    SwitchTurns();
                }
            }
        }
    }

    public void BeginMagic()
    {
        usingMagic = true;
        currentMagic += 1;
        Debug.Log(currentMagic);
        //when the timer runs out, needs to check isUsingMagic true (if it is, go to enemy/player healthbar and do damage in relation to the current magic value), set current magic back to 0, switch turns
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
        if (usingMagic == true)
        {
            usingMagic = false;
            //Do damage
            currentMagic = 0;
        }
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

                    StartCoroutine(RandomTrigger());
            }
        }
    }
}
