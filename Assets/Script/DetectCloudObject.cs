using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCloudObject : MonoBehaviour
{
    [SerializeField] private GameObject UseButton;
    [SerializeField] private GameObject CloudButton;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject cloud;

    private GameObject objectCloud;
    private GameObject objectFull;
    private Collider colliderTriggered;

    private TriggerManager triggerManager;

    private float scale = 0.1f;
    private float time = 100f;

    private void Start()
    {
        triggerManager = TriggerManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        CloudButton.SetActive(false);
        UseButton.SetActive(true);

        colliderTriggered = other;
    }

    private void OnTriggerExit(Collider other)
    {
        CloudButton.SetActive(false);
        UseButton.SetActive(false);

        colliderTriggered = null;
    }

    public void UseObject()
    {
        objectCloud = colliderTriggered.gameObject;
        objectFull = triggerManager.triggerInCloudToObjectFull[colliderTriggered];

        cloud.SetActive(false);
        objectFull.SetActive(true);

        setObjectOnCharacter();
    }

    //Lerp the full object to the trap or the character
    public void setObjectOnCharacter()
    {
        Vector3 positionObjectFull = objectFull.transform.position;
        Trap currentTrap = triggerManager.traps[triggerManager.triggerToTrapIndex[colliderTriggered.gameObject]];

        //Move the object to the target transform
        if (objectCloud.tag == "Fruit")
        {
            objectFull.transform.localScale = new Vector3(scale, scale, scale);
            objectFull.transform.position = Vector3.Lerp(positionObjectFull, character.transform.position, time);
            objectFull.transform.rotation = Quaternion.Slerp(objectFull.transform.rotation, character.transform.rotation, time);
        }
        else
        {
            Transform FinalPos = currentTrap.objectPos;

            objectFull.transform.localScale = FinalPos.localScale;
            objectFull.transform.position = Vector3.Lerp(FinalPos.position, character.transform.position, time);
            objectFull.transform.rotation = Quaternion.Slerp(FinalPos.rotation, character.transform.rotation, time);
        }

        StartCoroutine(objectAction(currentTrap));
    }

    //Do the action of the object
    IEnumerator objectAction(Trap trap)
    {
        yield return new WaitForSeconds(time);

        if (objectCloud.tag == "Fruit")
        {
            //TODO : heal player
        }
        else
        {
            switch (trap.type)
            {
                case TrapType.Destroy:
                    trap.trapObject.SetActive(false);
                    break;

                case TrapType.Open:
                    //TODO : Open
                    break;

                case TrapType.Place:
                    //TODO : désactiver les dégats du piège
                    break;
            }
        }
    }
}
