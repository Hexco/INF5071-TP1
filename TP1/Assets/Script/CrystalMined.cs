using UnityEngine;
using System.Collections;

public class CrystalMined : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (Input.GetKey("e"))
        {
            //TODO Peut etre rajouter lanimation de mining ici on verra
            //Animator animator = hero.GetComponent<Animator> ();
            //animator.Play ("MiningUp");
            MiningInterface.mined = 1;
            MiningInterface.x = other.transform.position.x;
            MiningInterface.z = other.transform.position.z;
            Destroy(this.gameObject);
        }
    }
}
