using UnityEngine;
using System.Collections;

public class CollectCrystal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (InventoryBackEnd.bagSize > (InventoryBackEnd.nbCrystal + InventoryBackEnd.nbIce))
        {
            InventoryBackEnd.nbCrystal+=1;
            //C'est la que sa pete pcq sa tombe sur un null. Comme si les element set dans la scene etait pas vraiment la.
            //Si tu trouve comment faire pour que se soit pas null tell me. Quand sa sera pu null, fait juste decommenter 
            //les deux derniere ligne pis on va torcher!

            //Inventory.AddItem(other.gameObject.GetComponent("Item") as Item);              //Add l'item
            Destroy(this.gameObject);                                                      //Detruit le clone apres l'avoir add
        }
    }
}