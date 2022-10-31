using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public RoomScript room;

    public Grid grid;
    public GameObject gridTile;

    public List<Vector2> availablePoints = new List<Vector2>();

    [System.Serializable]
    public struct Grid
    {
        public int columns, rows;
        public float verticalOffset, horizontalOffset;
    }

    private void Awake()
    {
        room = GetComponentInParent<RoomScript>();
        // Offset so gameObjects dont spawn in wall
        grid.columns = room.width - 6;
        grid.rows = room.height - 5;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        // Can set offset in inspector
        grid.verticalOffset += room.transform.localPosition.y;
        grid.horizontalOffset += room.transform.localPosition.x;
        
        // Instatiates new grid at every x and y co-ordinate
        for(int y = 0; y < grid.rows; y++)
        {
            for(int x = 0; x < grid.columns; x++)
            {
                GameObject GridOffset = Instantiate(gridTile, transform);
                GridOffset.GetComponent<Transform>().position = new Vector2(x - (grid.columns - grid.horizontalOffset), y - (grid.rows - grid.verticalOffset));
                // Sets gameobject name in hierarchy
                GridOffset.name = "X: " + x + ", Y: " + y;
                availablePoints.Add(GridOffset.transform.position);
                GridOffset.SetActive(false);
            }
        }
        GetComponentInParent<ObjectRoomSpawner>().InitaliseObject();
    }
}
