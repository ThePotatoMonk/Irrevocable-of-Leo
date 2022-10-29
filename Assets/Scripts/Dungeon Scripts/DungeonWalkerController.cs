using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonWalkerController : MonoBehaviour
{

    public enum Direction
    {up = 0, left = 1, down = 2, right = 3 }; 

    public static List<Vector2Int> positionsOld = new List<Vector2Int>();
    private static readonly Dictionary<Direction, Vector2Int> movementMap = new Dictionary<Direction, Vector2Int>
    {
        {Direction.up, Vector2Int.up },
        {Direction.left, Vector2Int.left },
        {Direction.down, Vector2Int.down },
        {Direction.right, Vector2Int.right }
    };


    
    public static List<Vector2Int> GenerateDungeon(DungeonSpawnerData dungeonData)
    {
        // Creates list of dungeon walkers
        List<DungeonWalker> dungeonWalkers = new List<DungeonWalker>();

        // For every i that is less
        for(int i = 0; i < dungeonData.walkersAmount; i++)
        {
            Debug.Log(dungeonData.walkersAmount);
            dungeonWalkers.Add(new DungeonWalker(Vector2Int.zero));
        }

        int loops = Random.Range(dungeonData.minLoop, dungeonData.maxLoop);

        for(int i = 0; i < loops; i++)
        {
            foreach(DungeonWalker dungeonWalker in dungeonWalkers)
            {
                Vector2Int Position = dungeonWalker.Move(movementMap);
                positionsOld.Add(Position);
            }
        }

        return positionsOld; 

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
