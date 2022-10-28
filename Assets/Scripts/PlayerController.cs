using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public Rigidbody2D rb; // Place Player here
    public GameObject bulletPrefab; // Place bullet prefab here
    private Vector2 moveTowards;
    private bool facingRight = true;

    //Player Stats
    [Header("Player Stats")]
    public float moveSpeed; // Movement Speed | default = 8
    public float attackRate; // Shooting delay
    public float attackSpeed; // Bullet speed
    public float attackSize; // Bullet Size
    public float attackRange; // Bullet Range
    private float lastAttack; //Time before last shot


    // Movement Stuff
    [Header("Movement Related")]
    [SerializeField] [ReadOnlyInspector] private float moveX; // Shows in inspector | Makes sure value cannot be edited
    [ReadOnlyInspector] [SerializeField] private float moveY;
    public float timeFromZeroToMax;  // How long it takes to reach max | default = 0.3f
    private float changeRatePerSecond; // Rate at which the value speeds up 

 

    private void Update()
    {


        DirectionalInputs();
        CombatInput();

    }
    private void FixedUpdate()
    {
        Move();
        Animate();
    }

    private void DirectionalInputs() // Function that takes users movement input
    {
        changeRatePerSecond = 1 / timeFromZeroToMax * Time.deltaTime;

        moveTowards.x = Input.GetAxisRaw("Horizontal");
        moveTowards.y = Input.GetAxisRaw("Vertical");

        moveTowards = moveTowards.normalized;

        // Moves itself towards 1 or -1 at the rate of changeRatePerSecond
        // Basically it accelerates or deccelerates at a specific rate
        moveX = Mathf.MoveTowards(moveX, moveTowards.x , changeRatePerSecond);
        moveY = Mathf.MoveTowards(moveY, moveTowards.y, changeRatePerSecond);
        
    }
    private void Move() // Move Function
    {
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
       
    }

    private void CombatInput() // Function that takes users combat input
    {
        float attackHori = Input.GetAxisRaw("AttackHorizontal");
        float attackVert = Input.GetAxisRaw("AttackVertical");
        //Checks 
        if ((attackHori != 0) && Time.time > lastAttack + attackRate)
        {
            Attack(attackHori, 0);
            lastAttack = Time.time;

        }
        if ((attackVert != 0) && Time.time > lastAttack + attackRate)
        {
            Attack(0, attackVert);
            lastAttack = Time.time;
        }
    }


    private void Attack(float x, float y) // Bullet Function
    {
        // Makes new gameobject
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        // If x,y < 0 then largest int of x,y is * bulletspeed | Else smallest int of x,y is * bulletspeed
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2
            ((x < 0) ? Mathf.Floor(x) * attackSpeed : Mathf.Ceil(x) * attackSpeed,
            (y < 0) ? Mathf.Floor(y) * attackSpeed : Mathf.Ceil(y) * attackSpeed);
    }


    private void Animate()
    {
        if (rb.velocity.x == 0)
        {
            return;
        }
        else if(rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if(rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip() // Flips Character GameObject
    {
        /* takes current scale and multiplies it by -1
         *  1 * -1 = -1 | -1 * -1 = 1*/
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight; // Equals opposite of current state
    }

 
}
