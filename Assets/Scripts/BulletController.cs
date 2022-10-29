using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(DeathDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(attackRange); //Destroys gameobject after alloted period
        Destroy(gameObject);
    }

    // Projectile collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }
    }

}
