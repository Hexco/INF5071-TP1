using UnityEngine;
using System.Collections;

public class IceSpawner : MonoBehaviour
{

    public Transform[] spawnIceLocations;
    public GameObject[] spawnIcePrefabs;
    public GameObject[] spawnIceClones;
    public static int dayIDIce = 1;
    protected int tomorrowIDIce = 2;

    public int getDayIDIce()
    {
        return dayIDIce;
    }

    void Start()
    {
        spawnCrystal();
    }

    void Update()
    {
        if (dayIDIce == tomorrowIDIce)
        {
            spawnCrystal();
            tomorrowIDIce++;
        }
    }

    void spawnCrystal()
    {
        for (int i = 0; i < 3; i++)
        {
            spawnIceClones[i] = Instantiate(spawnIcePrefabs[i], spawnIceLocations[i].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}
