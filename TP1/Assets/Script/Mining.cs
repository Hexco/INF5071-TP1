using UnityEngine;
using System.Collections;

public class Mining : MiningInterface
{
    public Transform[] chunkLocations = new Transform[3];
    public GameObject[] chunkPrefabs = new GameObject[3];
    public GameObject[] chunkClones = new GameObject[3];
    public static float mined = 0;
    public static float x = 0;
    public static float z = 0;

    void Update()
    {
        if (mined == 1)
        {
            spawnCrystals();
            mined = 0;
        }
    }

    public void spawnCrystals()
    {
        float howMuchCrystals = Random.Range(0, 3);
        for (int i = 0; i <= howMuchCrystals; i++)
        {
            int rndXYZ = Random.Range(-10, 10);
            Vector3 locationDynamique = new Vector3(x + rndXYZ, 2, z + rndXYZ);
            chunkClones[i] = Instantiate(chunkPrefabs[i], chunkLocations[i].transform.position = locationDynamique, Quaternion.Euler(0, 0, 0)) as GameObject;
            chunkClones[i].tag = "Item";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (Input.GetKey("e"))
        {
            //TODO Peut etre rajouter lanimation de mining ici on verra
            //Animator animator = hero.GetComponent<Animator> ();
            //animator.Play ("MiningUp");
            mined = 1;
            x = other.transform.position.x;
            z = other.transform.position.z;
            Destroy(this.gameObject);
        }
    }
}