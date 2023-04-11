using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int poolSize = 10;
    //GameObject[] enemyObjectPool;
    public List<GameObject> enemyObjectPool;

    public Transform[] spawnPoints;

    float currentTime;

    public float createTime = 1;

    public GameObject enemyFactory;

    float minTime = 1;
    float maxTime = 5;


    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        //enemyObjectPool = new GameObject[poolSize];
        enemyObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            //enemyObjectPool[i] = enemy;
            enemyObjectPool.Add(enemy);

            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime> createTime)
        {
            //GameObject enemy = Instantiate(enemyFactory);

            /*for (int i=0; i<poolSize; i++)
            {
                GameObject enemy = enemyObjectPool[i];

                if(enemy.activeSelf==false)
                {
                    enemy.SetActive(true);

                    int index = Random.Range(0, spawnPoints.Length);
                    enemy.transform.position = spawnPoints[index].position;
                    //enemy.transform.position = transform.position;
                    break;
                }
            }*/
            GameObject enemy = enemyObjectPool[0];
            if(enemyObjectPool.Count>0)
            {
                enemy.SetActive(true);
                enemyObjectPool.Remove(enemy);
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
            }

            //createTime = Random.Range(minTime, maxTime);
            createTime = Random.Range(minTime, maxTime)*0.2f;
            currentTime = 0;
        }
    }
}
