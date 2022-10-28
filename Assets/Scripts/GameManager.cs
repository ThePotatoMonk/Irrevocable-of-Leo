using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Variables
    public static GameManager instance;
    private static int health = 6;
    private static int maxHealth = 6;       
    private static float moveSpeed = 8f;    
    private static float attackRate = 0.5f;

    public static float timeInvincible = 2.0f;
    private static bool isInvincible = false; 

    // makes these variables accessable in a certain way   
    public static int Health { get => health; set => health = value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; } 
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; } 
    public static float FireRate { get => attackRate; set => attackRate = value; }

    public static event Action OnPlayerDamaged;


private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void TakeDamage(int damage)
    {
        if(!isInvincible)
        {
            health -= damage;
            OnPlayerDamaged?.Invoke();
            Debug.Log("Health: " + health + "/" + maxHealth);
            if (health <= 0)
            {
                Debug.Log("Health < 0");
                KillPlayer();
            }
        }

    }

    
    public static void MoveSpeedChange(float speed)
    {
        moveSpeed += speed;
    }

    public static void FireRateChange(float rate)
    {
        attackRate -= rate;
    }

    public static void HealPlayer(int healAmount)
    {
        Health = Mathf.Min(maxHealth, Health + healAmount);
    }

    private static void KillPlayer()
    {
        Debug.Log("Killplayer");
    }

}
