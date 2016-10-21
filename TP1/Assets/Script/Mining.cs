using UnityEngine;
using System.Collections;

public class Mining : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] spawnPrefabs;
    public GameObject[] spawnClones;
    public int dayID = 1;

    void Start()
    {
        spawnCrystals();
      //  Destroy(spawnClones[0]);
    }

    void Update()
    {
        dayID++;
//        if (dayID % 7 == 0)
//        {
 //           Destroy(spawnClones[0]);
  //      }
     
        if (dayID/10 > 30 && spawnClones[0] == null)
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
            spawnClones[0] = Instantiate(spawnPrefabs[0], spawnLocations[0].transform.position = locationDynamique, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}