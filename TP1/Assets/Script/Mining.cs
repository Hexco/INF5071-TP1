using UnityEngine;
using System.Collections;

public class Mining : Spawner
{
    public Transform[] chunkLocations;
    public GameObject[] chunkPrefabs;
    public GameObject[] chunkClones;

    void Start()
    {
        chunkClones[0] = null;
    }

    void Update()
    {
        if (dayID == tomorrowID && chunkClones[0] != null)
        {
            Destroy(chunkClones[0]);
        }
     
        if (dayID/3 > 20 && chunkClones[0] == null)
        {
            spawnCrystals();
        }
    }

    void spawnCrystals()
    {
        float howMuchCrystals = Random.Range(0, 4);
        for (float i = 0; i <= howMuchCrystals; i++)
        {
            int rndXYZ = Random.Range(-40, 40);
            Vector3 locationDynamique = new Vector3(475 + rndXYZ, 2, 31 + rndXYZ);
            chunkClones[0] = Instantiate(chunkPrefabs[0], chunkLocations[0].transform.position = locationDynamique, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}