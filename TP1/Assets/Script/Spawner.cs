using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] spawnPrefabs;
    public GameObject[] spawnClones;
    public int dayID=1;
    public int yesterdayID = 0;

    void Start()
    {
        spawnCrystal();
        yesterdayID=1;
    }

    void Update()
    {
        dayID++;
        if (dayID == 30)
        {
            Destroy(spawnClones[0]);
        }

        if(dayID >= 60)
        {
            int probability = Random.Range(0,500);
            if (probability == 4 && spawnClones[0] == null)
            {
                spawnClones[0] = Instantiate(spawnPrefabs[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }
    }

    void spawnCrystal()
    {
        spawnClones[0] = Instantiate(spawnPrefabs[0], spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
    }
}
