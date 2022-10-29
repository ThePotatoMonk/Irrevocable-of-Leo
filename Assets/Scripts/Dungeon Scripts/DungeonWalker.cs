using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DungeonWalkerController;

public class DungeonWalker : MonoBehaviour
{
    public Vector2Int Position;

    public DungeonWalker(Vector2Int position)
    {
        Position = position;
    }


    public Vector2Int Move(Dictionary<Direction, Vector2Int> movementMap)
    {
        Direction moveTarg = (Direction)Random.Range(0, movementMap.Count);
        Position += movementMap[moveTarg];
        return Position;
    }
}
