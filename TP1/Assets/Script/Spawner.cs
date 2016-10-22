using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] spawnPrefabs;
    public GameObject[] spawnClones;
    protected int dayID=1;
    protected int tomorrowID = 0;

    public int getDayID()
    {
        return dayID;
    }

    void Start()
    {
        spawnCrystal();
        tomorrowID = 2;
    }

    void Update()
    {
        dayID++;
        if (dayID == 30)
        {
            Destroy(spawnClones[0]);
        }

        if(dayID == tomorrowID)
        {
            int probability = Random.Range(0,300);
            if (probability == 4 && spawnClones[0] == null)
            {
                spawnCrystal();
            }
            tomorrowID++;
        }
    }

    void spawnCrystal()
    {
        spawnClones[0] = Instantiate(spawnPrefabs[0], spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
    }
}
