using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorType { left, right, top, bottom }

    public DoorType doorType;

    public GameObject doorCollider;

    private GameObject player;
    private float horizontalOffset = 1.75f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // When player collides with collider, they will teleport into the next room
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            switch(doorType)
            {
                case DoorType.top:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y + horizontalOffset);
                    break;

                case DoorType.bottom:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y - horizontalOffset);
                    break;

                case DoorType.left:
                    player.transform.position = new Vector2(transform.position.x - horizontalOffset, transform.position.y);
                    break;

                case DoorType.right:
                    player.transform.position = new Vector2(transform.position.x + horizontalOffset, transform.position.y);
                    break;

            }
        }
    }

}
