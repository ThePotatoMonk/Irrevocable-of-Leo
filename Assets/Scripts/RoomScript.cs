using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    //Variables
    public int height;
    public int width;
    public int x;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        //Makes sure that roomcontroller is instanced by making sure that you are in the main scene
        if(RoomController.instance == null)
        {
            Debug.Log("Please Load Main Scene");
            return;
        }

        RoomController.instance.AddRoom(this);

    }



    public Vector3 GetRoomCenter()
    {

        return new Vector2(x * width, y * height);
    }
}
