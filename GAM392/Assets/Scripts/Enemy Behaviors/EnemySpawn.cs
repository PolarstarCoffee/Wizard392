using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefab; //enemy prefab 
    public float spawnTime; 
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", spawnTime, spawnDelay);
    }

   void spawnEnemy()
    {
        Instantiate(enemyPrefab[UnityEngine.Random.Range(0, enemyPrefab.Length)], transform.position, Quaternion.identity);
    }
    void OnEnable()
    {
        //Enemy.OnNoteKilled += spawnEnemy;
    }
}
