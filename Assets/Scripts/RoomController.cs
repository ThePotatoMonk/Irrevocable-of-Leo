using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    bool isLoadingRoom = false;

    private void Awake()
    {
        instance = this; //Creates instance of "this" which is the room
    }

    private void Start()
    {
        
        LoadScene("Start", 0, 0); 
        LoadScene("Empty", 1, 0);  //Loads each room at the start
        LoadScene("Empty", -1, 0); //Loads one empty room adjacent to each side of the main room.
        LoadScene("Empty", 0, 1);
        LoadScene("Empty", 0, -1);

    }

    private void Update()
    {
        UpdateRoomQueue();
    }

    void UpdateRoomQueue() 
    {
        if(isLoadingRoom)
        {
            return;
        }

        if(loadRoomQueue.Count == 0)
        {
            return;
        }
        Debug.Log("1" + currentLoadRoomData);
        currentLoadRoomData = loadRoomQueue.Dequeue();
        Debug.Log("2" + currentLoadRoomData);
        isLoadingRoom = true;

        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }

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

    public void AddRoom(RoomScript room)
    {
        room.transform.position = new Vector2(currentLoadRoomData.X * room.width, currentLoadRoomData.Y * room.height);

        room.x = currentLoadRoomData.X;
        room.y = currentLoadRoomData.Y;
        room.name = currentLevel + "-" + currentLoadRoomData.name + " " + room.x + ", " + room.y;
        room.transform.parent = transform;

        //Room is loaded
        isLoadingRoom = false;

        //Adds room to list
        loadedRooms.Add(room); 
    }
}

