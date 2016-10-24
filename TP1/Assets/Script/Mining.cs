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
        chunkClones[1] = null;
        chunkClones[2] = null;
        chunkClones[3] = null;
    }

    void Update()
    {
        if (dayID == tomorrowID && chunkClones[0] != null)
        {
            Destroy(chunkClones[0]);
        }
     
        if (Input.GetKey("e") && chunkClones[0] == null)
        {
            spawnCrystals();
        }
    }

    void spawnCrystals()
    {
        float howMuchCrystals = Random.Range(0, 4);
        for (int i = 0; i <= howMuchCrystals; i++)
        {
            int rndXYZ = Random.Range(-10, 10);
            Vector3 locationDynamique = new Vector3(475 + rndXYZ, 2, 31 + rndXYZ);
            chunkClones[i] = Instantiate(chunkPrefabs[0], chunkLocations[0].transform.position = locationDynamique, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        print("FUCK");
        //Destroy(chunkClones[0]);
    }
}