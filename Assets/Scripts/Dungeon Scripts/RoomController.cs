    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Stores information
public class RoomData
{
    public string name;
    public int X; //Stores the co-ordinates of the rooms
    public int Y; // (X,Y) correspond to the rooms like (1,0)
}


public class RoomController : MonoBehaviour
{

    //Variables
    public static RoomController instance;

    RoomData currentLoadRoomData;

    Queue<RoomData> loadRoomQueue = new Queue<RoomData>();

    string currentLevel = "Cellar";

    public List<RoomScript> loadedRooms = new List<RoomScript>();

    RoomScript currentRoom;

    bool isLoadingRoom = false;

    private void Awake()
    {
        instance = this; //Creates instance of "this" which is the room
    }

    private void Start()
    {
        

    }

    private void Update()
    {
        UpdateRoomQueue();
    }


    // Updates the queue
    void UpdateRoomQueue() 
    {
        // If loading, nothing
        if(isLoadingRoom)
        {
            return;
        }

        // If nothing in queue, nothing
        if(loadRoomQueue.Count == 0)
        {
            return;
        }

        // Takes room out of the queue and puts it in loadroomdata
        Debug.Log("1" + currentLoadRoomData);
        currentLoadRoomData = loadRoomQueue.Dequeue();
        Debug.Log("2" + currentLoadRoomData);
        isLoadingRoom = true;

        // Starting coroutine
        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }
    // Loads the currentLoadRoomData into the scene
    IEnumerator LoadRoomRoutine(RoomData info) //Coroutine allows us to run this method across multiple frames instead of instantly.
    {
        string levelName = currentLevel + info.name;
        //Loads scene asynchronously in the background
        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        //Make sure room is finished loading
        while (loadRoom.isDone == false)
        {
            yield return null;
        }
    }

    // Loads scene (rooms)
    public void LoadScene(string name, int x, int y)
    {
        //Checks if room exists before loading new scene
        if(RoomChecker(x, y))
        {
            return;
        }
        //Sets new information
        RoomData newRoomData = new RoomData();
        newRoomData.name = name;
        newRoomData.X = x;
        newRoomData.Y = y;

        //This is like an array. Enqueue adds a new object to itself. 
        loadRoomQueue.Enqueue(newRoomData);
    }


    public bool RoomChecker(int x, int y)
    {
        // checks for each active rooms. returns true or false   
        return loadedRooms.Find(item => item.x == x && item.y == y) != null;
    }


    // Sets room data like position for spawning rooms
    public void AddRoom(RoomScript room)
    {
        room.transform.position = new Vector2(currentLoadRoomData.X * room.width, currentLoadRoomData.Y * room.height);


        // Sets room positions to the room data
        room.x = currentLoadRoomData.X;
        room.y = currentLoadRoomData.Y;
        room.name = currentLevel + "-" + currentLoadRoomData.name + " " + room.x + ", " + room.y;
        room.transform.parent = transform;

        //Room is loaded
        isLoadingRoom = false;

        if(loadedRooms.Count == 0)
        {
            CameraController.instance.currentRoom = room;
        }

        //Adds room to list
        loadedRooms.Add(room); 
    }

    // When player enters the room it sets current room
    public void OnPlayerEnterRoom(RoomScript room)
    {
        CameraController.instance.currentRoom = room;
        currentRoom = room;
    }



}

