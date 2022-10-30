using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonWalkerController : MonoBehaviour
{

    public enum Direction
    {up = 0, left = 1, down = 2, right = 3 }; 

    public static List<Vector2Int> positionNew = new List<Vector2Int>();
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

        // Random number of walkers between the constraints we set
        int walkersAmount = Random.Range(dungeonData.walkersAmountMin, dungeonData.walkersAmountMax);
        for(int i = 0; i < walkersAmount; i++)
        {
            dungeonWalkers.Add(new DungeonWalker(Vector2Int.zero));
        }

        // Random number set between min and max loops
        int loops = Random.Range(dungeonData.minLoop, dungeonData.maxLoop);
        // Iterates through whatever the random number is
        for(int i = 0; i < loops; i++)
        {
            foreach(DungeonWalker dungeonWalker in dungeonWalkers)
            {
                // Moves new position by 1
                Vector2Int Position = dungeonWalker.Move(movementMap);
                positionNew.Add(Position);
            }
        }

        return positionNew; 

    }


}
