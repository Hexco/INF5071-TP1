using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {
    void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
