using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProperties : MonoBehaviour {

    [HideInInspector]
    public float speed;
    public float startSpeed = 10;
    public int startHealth = 100;
    private float health;
    public int moneyValue = 20;
    public Image healthBar;
    public GameObject deathEffect;
    // Use this for initialization
    void Start () {
        health = startHealth;
        speed= startSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float amount)
    {
        health -= amount;
        float dmg = health / startHealth;
        healthBar.fillAmount = dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float slow)
    {
        speed = startSpeed * (1f - slow);
    }

    void Die()
    {
        //get money 
        GameResources.Money += moneyValue;
        WaveSpawner.enemiesAlive--;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5);
        Destroy(gameObject);
    }
}
