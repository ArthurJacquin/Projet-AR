using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject useFruitButton;
    [SerializeField] private GameObject fruit;

    private void OnTriggerEnter(Collider other)
    {
        useFruitButton.SetActive(true);
        UseChestButton.fruit = fruit;
    }

    private void OnTriggerExit(Collider other)
    {
        useFruitButton.SetActive(false);
        UseChestButton.fruit = null;
    }

}
