using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCloudObject : MonoBehaviour
{
    public Text debug;
    private void OnTriggerEnter(Collider other)
    {
        //TODO : activer le bouton "use"
        debug.text = "trouvé";
        Debug.Log(other.gameObject.name + " trouvé !");
    }

    private void OnTriggerExit(Collider other)
    {
        //TODO : Desactiver le bouton "use"
        debug.text = "Sortie";
        Debug.Log(other.gameObject.name + " sortie !");
    }
}
