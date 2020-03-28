using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;

    public Transform[] spawnPoints;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int randSpawn = Random.Range(0, spawnPoints.Length);
            int randObstacle = Random.Range(0, obstacles.Length);
            GameObject tempEnemy = Instantiate(obstacles[randObstacle], spawnPoints[randSpawn].position, new Quaternion(0f, 0f, Random.Range(0f, 180f), 0f));
            //tempEnemy.transform.parent = gameObject.transform.parent;
            //tempEnemy.transform.position = new Vector3(tempEnemy.transform.position.x, tempEnemy.transform.position.y - obstacleSpeed * Time.deltaTime);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
