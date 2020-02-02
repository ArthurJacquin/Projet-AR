using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCloud : MonoBehaviour
{
    [SerializeField] private GameObject cloudButton;

    private void OnTriggerEnter(Collider other)
    {
        cloudButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        cloudButton.SetActive(false);
    }

}
