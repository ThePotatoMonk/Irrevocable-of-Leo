using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables
    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 3f;
    public float health = 3f;
    public float maxHealth = 3f;
    public static EnemyController Instance;

    public bool idle;
    public bool attacking;
    public bool notInRoom = true;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player"); // Looks for player
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position; //Calculates direction
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        if(!notInRoom)
        {
            Enemy(movement);
        }
        else
        {
            Debug.Log("Idle");
        }


    }

    // Enemy taking damage
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0 )
        {
            Destroy(gameObject);
        }
    }

    // Moves enemy towards player
    private void Enemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime)); 
    }


    // When something collides with Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if(player != null)
        {
            Debug.Log("hurted");
            GameManager.TakeDamage(1);
        }
    }
}

