using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    //Variables
    public int height;
    public int width;
    public int X;
    public int Y;



    public Door topDoor;
    public Door bottomDoor;
    public Door leftDoor;
    public Door rightDoor;

    public List<Door> doors = new List<Door>();
    private bool updatedDoors;

    // Start is called before the first frame update
    void Start()
    {
        //Makes sure that roomcontroller is instanced by making sure that you are in the main scene
        if(RoomController.instance == null)
        {
            Debug.Log("Please Load Main Scene");
            return;
        }

        Door[] deez = GetComponentsInChildren<Door>();
        //
        foreach(Door d in deez)
        {
            doors.Add(d);
            switch(d.doorType)
            {
                case Door.DoorType.top:
                    topDoor = d;
                    break;
                case Door.DoorType.bottom:
                    bottomDoor = d;
                    break;
                case Door.DoorType.left:
                    leftDoor = d;
                    break;
                case Door.DoorType.right:
                    rightDoor = d;
                    break;
            }
        }

        RoomController.instance.AddRoom(this);

    }

    private void Update()
    { 
        if(name.Contains("Boss") && !updatedDoors)
        {
            RemoveDoors();
            updatedDoors = true;
        }
    }
    // Gets room center
    public Vector3 GetRoomCenter()
    {

        return new Vector2(X * width, Y * height);
    }


    // Collision function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }

    //Removes doors that are not connected
    public void RemoveDoors()
    {
        foreach(Door door in doors)
        {
            switch(door.doorType)
            {
                case Door.DoorType.top:
                    if (GetTop() == null)
                        door.gameObject.SetActive(false);
                    break;
                case Door.DoorType.bottom:
                    if (GetBottom() == null)
                        door.gameObject.SetActive(false);
                    break;
                case Door.DoorType.right:
                    if (GetRight() == null)
                        door.gameObject.SetActive(false);
                    break;
                case Door.DoorType.left:
                    if (GetLeft() == null)
                        door.gameObject.SetActive(false);
                    break;
            }
        }
    }

    public RoomScript GetTop()
    {
        if (RoomController.instance.RoomChecker(X, Y + 1))
        {
            return RoomController.instance.RoomFinder(X, Y + 1);
        }
        return null;
    }
    public RoomScript GetBottom()
    {
        if (RoomController.instance.RoomChecker(X, Y -1))
        {
            return RoomController.instance.RoomFinder(X, Y - 1);
        }
        return null;
    }
    public RoomScript GetLeft()
    {
        if (RoomController.instance.RoomChecker(X - 1, Y))
        {
            return RoomController.instance.RoomFinder(X - 1, Y);
        }
        return null;
    }
    public RoomScript GetRight()
    {
        if (RoomController.instance.RoomChecker(X + 1, Y))
        {
            return RoomController.instance.RoomFinder(X + 1, Y);
        }
        return null;
    }
    public RoomScript(int x, int y)
    {
        X = x;
        Y = y;
    }
}
