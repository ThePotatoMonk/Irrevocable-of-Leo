using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    //Variables
    public GameObject ItemPrefab;
    public float Radius = 1;
    private int numberOfEnemies;

    private void Start()
    {
        numberOfEnemies = Random.Range(1, 5);
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnObjectAtRandom();
        }
    }

        // Spawns the selected item prefab inside the circle randomly
        void SpawnObjectAtRandom()
        {
            Vector3 randomPos = Random.insideUnitCircle * Radius;

            Instantiate(ItemPrefab, randomPos, Quaternion.identity, this.transform);

        }


}
