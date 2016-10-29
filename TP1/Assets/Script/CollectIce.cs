using UnityEngine;
using System.Collections;

public class CollectIce : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (InventoryBackEnd.bagSize > (InventoryBackEnd.nbCrystal + InventoryBackEnd.nbIce))
        {
            InventoryBackEnd.nbIce+=1;
            Destroy(this.gameObject);
        }
    }
}