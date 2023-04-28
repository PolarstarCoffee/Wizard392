using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

   void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoints[0].transform.position, Quaternion.identity);
    }
}
