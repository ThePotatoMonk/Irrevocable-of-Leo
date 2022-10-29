using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public RoomScript currentRoom;

    public float speedChange;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        //If currentRoom is same then it doesnt do anything
        if(currentRoom == null)
        {
            return;
        }

        Vector3 targetPosition = CameraTargetPosition();
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speedChange);
    }

    // Gets camera's target position ie next location
    private Vector3 CameraTargetPosition()
    {
        if (currentRoom == null)
        {
            return Vector3.zero; // Keeps camera in middle
        }

        Vector3 targetPosition = currentRoom.GetRoomCenter();
        targetPosition.z = transform.position.z;

        return targetPosition;
    }

    public bool SwitchingSCene()
    {
        // Equals checks if transform.position is equal to the camera target position
        // If the camera is equal to the place it is meant to be
        return transform.position.Equals(CameraTargetPosition()) == false;
    }

}
