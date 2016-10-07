using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] itemPrefabs;

    [SerializeField]
    private float startDelay;

    [SerializeField]
    private float spawnDelay;

    private int pooledAmount = 5;
    private List<GameObject> items;

	void Start() 
	{
        items = new List<GameObject>();

        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
            item.SetActive(false);
            items.Add(item);
        }

        InvokeRepeating("Spawn", startDelay, spawnDelay);
    }

    void Spawn()
    {
        for (int i = 0; i < items.Count; i++)
        {

            GameObject item = items[Random.Range(0, items.Count)];

            if (!item.activeInHierarchy)
            {
                item.transform.position = new Vector3(Random.Range(-5, 10), 5.4f);
                item.transform.rotation = Quaternion.identity;
                item.SetActive(true);
                break;
            }
        }
    }

    void OnDisable()
    {
        CancelInvoke();
    }

}