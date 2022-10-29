using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    public DungeonSpawnerData dungeonSpawnerData;
    private List<Vector2Int> dungeonRooms;

    private void Start()
    {
        dungeonRooms = DungeonWalkerController.GenerateDungeon(dungeonSpawnerData);
        SpawnRooms(dungeonRooms);
    }

    // Spawns the rooms
    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        //When first loading it spawns the starting room
        RoomController.instance.LoadScene("Start", 0, 0);
        // Iterates through each room and spawns empty room in each location
        foreach(Vector2Int roomLocation in rooms)
        {
            RoomController.instance.LoadScene("Empty", roomLocation.x, roomLocation.y);
        }
    }
}
