using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCloudObject : MonoBehaviour
{
    [SerializeField] private GameObject UseButton;
    [SerializeField] private GameObject CloudButton;

    public Text debug;

    private void OnTriggerEnter(Collider other)
    {
        CloudButton.SetActive(false);
        UseButton.SetActive(true);

        debug.text = "trouvé";
        Debug.Log(other.gameObject.name + " trouvé !");
    }

    private void OnTriggerExit(Collider other)
    {
        CloudButton.SetActive(false);
        UseButton.SetActive(false);

        debug.text = "Sortie";
        Debug.Log(other.gameObject.name + " sortie !");
    }
}
