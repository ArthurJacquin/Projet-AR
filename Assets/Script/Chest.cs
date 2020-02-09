using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject useFruitButton;

    private void OnTriggerEnter(Collider other)
    {
        useFruitButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        useFruitButton.SetActive(false);
    }
}
