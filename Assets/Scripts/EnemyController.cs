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

    // Start is called before the first frame update
    void Start()
    {
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
        Enemy(movement);
    }

    private void Enemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime)); // Moves enemy towards player
    }

    public void Death()
    {
        Destroy(gameObject);
    }
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

