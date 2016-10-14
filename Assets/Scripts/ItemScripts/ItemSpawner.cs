using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour {

    //the items that will be spawned
    [SerializeField]
    private GameObject[] itemPrefabs;

    //the delay in starting to spawn the items
    [SerializeField]
    private float startDelay;

    //the delay in between each item that is spawned
    [SerializeField]
    private float spawnDelay;

    //amount of items instantiated at the start of the game
    private int pooledAmount = 5;
    //list to store items
    private List<GameObject> items;

	void Start() 
	{
        items = new List<GameObject>();

        for(int i = 0; i < pooledAmount; i++)
        {
            //instantiates random items from the itemPrefabs array
            GameObject item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
            item.SetActive(false);
            //adds the items to the list
            items.Add(item);
        }

        //call the spawn method in startDelay seconds and call the method repeatedly after that in spawnDelay seconds
        InvokeRepeating("Spawn", startDelay, spawnDelay);
    }

    void Spawn()
    {
        for (int i = 0; i < items.Count; i++)
        {
            //choose a random instantiated item
            GameObject item = items[Random.Range(0, items.Count)];

            //if the item is disabled then...
            if (!item.activeInHierarchy)
            {
                //...set the position to be at a random spot on the screen and above the playing area
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