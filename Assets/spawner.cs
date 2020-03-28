using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;

    public GameObject[] spawns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, spawns.Length);
            GameObject tempEnemy = Instantiate(enemy, spawns[rand].transform.position, Quaternion.identity);
            tempEnemy.transform.parent = gameObject.transform.parent;
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
                startTimeBtwSpawn -= decreaseTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
