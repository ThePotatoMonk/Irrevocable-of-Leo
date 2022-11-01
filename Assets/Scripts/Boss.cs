using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{

    // Variables
    private GameObject player;
    public float health;
    public float maxHealth = 25f;

    public static Boss Instance;
    public static event Action OnEnemyKilled;
    public static event Action OnBossDeath;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
    }

    // Boss taking damage
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Boss: " + health + "/" + maxHealth);

        if (health <= 0)
        {
            OnEnemyKilled?.Invoke();
            OnBossDeath?.Invoke();
            RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
            Destroy(gameObject);

        }
    }

    // Player taking damage when colliding
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            Debug.Log("hurted");
            GameManager.TakeDamage(1);
        }
    }
}
