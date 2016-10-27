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
        if(dayID == tomorrowID)
        {
            //spawnCrystal();
            tomorrowID++;
        }
    }

    void spawnCrystal()
    {
        for (int i = 0; i < 3; i++)
        {
            int probability = Random.Range(0, 100);
            spawnClones[i] = Instantiate(spawnPrefabs[i], spawnLocations[i].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }   
    }
}
