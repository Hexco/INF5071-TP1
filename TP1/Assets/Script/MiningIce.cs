using UnityEngine;
using System.Collections;

public class MiningIce : MiningInterface
{
    public Transform[] IceChunkLocations = new Transform[3];
    public GameObject[] IceChunkPrefabs = new GameObject[3];
    public GameObject[] IceChunkClones = new GameObject[3];
    public static float iceMined = 0;
    public static float iceX = 0;
    public static float iceZ = 0;

    void Update()
    {
        if (iceMined == 1)
        {
            spawnIce();
            iceMined = 0;
        }
    }

    public void spawnIce()
    {
        float howMuchCrystals = Random.Range(0, 3);
        for (int i = 0; i <= howMuchCrystals; i++)
        {
            int rndXYZ = Random.Range(-10, 10);
            Vector3 locationDynamique = new Vector3(iceX + rndXYZ, 2, iceZ + rndXYZ);
            IceChunkClones[i] = Instantiate(IceChunkPrefabs[i], IceChunkLocations[i].transform.position = locationDynamique, Quaternion.Euler(0, 0, 0)) as GameObject;
            IceChunkClones[i].tag = "Item";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (Input.GetKey("e"))
        {
            //TODO Peut etre rajouter lanimation de mining ici on verra
            //Animator animator = hero.GetComponent<Animator> ();
            //animator.Play ("MiningUp");
            iceMined = 1;
            iceX = other.transform.position.x;
            iceZ = other.transform.position.z;
            Destroy(this.gameObject);
        }
    }
}
