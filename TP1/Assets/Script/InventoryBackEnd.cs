using UnityEngine;
using System.Collections;

public class InventoryBackEnd : MonoBehaviour {
    public static float nbIce = 0;
    public static float nbCrystal = 0;
    public static float bagSize = 30;

    void Start()
    {
        print("Init Crystal: " + InventoryBackEnd.nbCrystal);
        print("Init Ice: " + InventoryBackEnd.nbIce);

        nbIce = 0;
        nbCrystal = 0;
    }
}
