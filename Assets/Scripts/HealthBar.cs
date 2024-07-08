using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
	public Slider healthSlider;
	public Slider easeHealthSlider;
	public float maxHealth = 100f;
	public float health;
	private float lerpSpeed = 0.05f;
	public Healthbar healthbar;
	public GameObject Character;

	



	void Start()
	{
		health = maxHealth;
	}

	void Update()
	{
		if(healthSlider.value != health)
		{
			healthSlider.value = health;
		}

		if(healthSlider.value != easeHealthSlider.value)
		{
			easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
		}
	}

    public void Die()
    {
        healthbar.gameObject.SetActive(false);
		Destroy(GameObject.FindWithTag("Enemy"));
		
    }

    public void TakeDamage(float damage)
	{
		health -= damage;
		if(health <=0)
		{
			Die();
		}
	}
}
