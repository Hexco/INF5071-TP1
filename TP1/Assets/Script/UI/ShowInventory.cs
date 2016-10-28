using UnityEngine;
using System.Collections;

public class ShowInventory : MonoBehaviour
{

    public GameObject inventaire; // Assign in inspector
    private bool isActive;

    void FixedUpdate()
    {
        if (Input.GetKeyDown("i"))
        {
            isActive = !isActive;
            inventaire.SetActive(isActive);
        }
    }

    public void resumeGame()
    {
        isActive = !isActive;
        inventaire.SetActive(isActive);
    }
}