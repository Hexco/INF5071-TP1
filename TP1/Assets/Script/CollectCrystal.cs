using UnityEngine;
using System.Collections;

public class CollectCrystal : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (InventoryBackEnd.bagSize > (InventoryBackEnd.nbCrystal + InventoryBackEnd.nbIce))
        {
            InventoryBackEnd.nbCrystal+=1;
            Destroy(this.gameObject);
        }
    }
}