using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCloud : MonoBehaviour
{
    [SerializeField] private GameObject cloudButton;
    private DetectCloudObject DetectCloudObject;

    private void OnTriggerEnter(Collider other)
    {
        cloudButton.SetActive(true);
        DetectCloudObject.triggeredTrap = this.GetComponent<Collider>();
    }

    private void OnTriggerExit(Collider other)
    {
        cloudButton.SetActive(false);
    }

}
