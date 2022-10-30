using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonSpawnerData.asset", menuName = "DungeonSpawnerData/Dungeon Data")]



public class DungeonSpawnerData : ScriptableObject
{
    // Variables
    public int walkersAmountMin;
    public int walkersAmountMax;
    public int minLoop;
    public int maxLoop;


}
