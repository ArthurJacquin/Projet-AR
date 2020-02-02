using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCloudObject : MonoBehaviour
{
    [SerializeField] private GameObject UseButton;
    [SerializeField] private GameObject CloudButton;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject objectFull;
    [SerializeField] private GameObject objectCloud;

    [SerializeField] private float scale;
    [SerializeField] private float time;
    [SerializeField] private Transform finalPosition;

    public bool click = false;
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
        click = false;

        debug.text = "Sortie";
        Debug.Log(other.gameObject.name + " sortie !");
    }

    public void setObjectOnCharacter()
    {
        click = true;
        objectCloud.SetActive(false);

        objectFull.SetActive(true);
        Vector3 positionObjectFull = objectFull.transform.position;

        if (objectCloud.tag == "Fruit")
        {
            objectFull.transform.localScale = new Vector3(scale, scale, scale);
            objectFull.transform.position = Vector3.Lerp(positionObjectFull, character.transform.position, time);
            objectFull.transform.rotation = Quaternion.Slerp(objectFull.transform.rotation, character.transform.rotation, time);
        }
        else
        {
            objectFull.transform.localScale = finalPosition.localScale;
            objectFull.transform.position = Vector3.Lerp(finalPosition.position, character.transform.position, time);
            objectFull.transform.rotation = Quaternion.Slerp(finalPosition.rotation, character.transform.rotation, time);
        }

    }

}
