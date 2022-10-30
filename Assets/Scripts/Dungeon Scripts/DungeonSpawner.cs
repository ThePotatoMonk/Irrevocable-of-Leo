using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    public DungeonSpawnerData dungeonSpawnerData;
    private List<Vector2Int> dungeonRooms;

    public string[] EmptyRooms = { "Empty", "Shop", "Treasure"}; // List of possible rooms  
    private Vector2Int[] noBoss = {Vector2Int.up, Vector2Int.down,Vector2Int.left, Vector2Int.right};

    int bossSpawned = 0;
   
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
        foreach (Vector2Int roomLocation in rooms)
        {
            if(roomLocation == dungeonRooms[dungeonRooms.Count - 1] && !(roomLocation == Vector2Int.zero))
            {
                RoomController.instance.LoadScene("Boss", roomLocation.x, roomLocation.y);
                
            }
            else
            {
                RoomController.instance.LoadScene(EmptyRooms.RandomItem().ToString(), roomLocation.x, roomLocation.y);
            }
            
        }
    }


}
public static class ArrayExtensions
{
    // This is an extension method. RandomItem() will now exist on all arrays.
    public static T RandomItem<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}

