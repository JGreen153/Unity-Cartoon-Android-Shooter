using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private float startDelay;

    [SerializeField]
    private float spawnDelay = 3;

    private int pooledAmount = 10;
    private List<GameObject> enemies;

    // Use this for initialization
	void Start() 
	{
        enemies = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
            enemy.SetActive(false);
            enemies.Add(enemy);
        }

        InvokeRepeating("Spawn", startDelay, spawnDelay);       
	}

    void Spawn()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                enemies[i].transform.position = new Vector3(14.0f, Random.Range(-3.8f, 3.8f));
                enemies[i].transform.rotation = Quaternion.identity;
                enemies[i].SetActive(true);
                break;
            }
        }
    }

    void OnDisable()
    {
        CancelInvoke();
    }

}