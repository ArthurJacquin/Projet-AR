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

    [HideInInspector] public static Collider triggeredTrap;

    private GameObject objectCloud;
    private GameObject objectFull;

    private Collider colliderTriggeredInCloud;

    private TriggerManager triggerManager;

    private float scale = 2f;
    private float speed = 0.004f;
    private bool lerpObject = false;
    private Transform lerpStart;
    private Transform lerpEnd;

    [SerializeField] public LifeScript life;
    
    private void Start()
    {
        triggerManager = TriggerManager.instance;
    }

    //Detect if an object is found in the cloud
    private void OnTriggerEnter(Collider other)
    {
        if(this.tag == "MainCamera")
        {
            CloudButton.SetActive(false);
            UseButton.SetActive(true);

            colliderTriggeredInCloud = other;
        }
    }

    //Detect if an object is lost in the cloud
    private void OnTriggerExit(Collider other)
    {
        if (this.tag == "MainCamera")
        {
            CloudButton.SetActive(false);
            UseButton.SetActive(false);
        }
    }

    //Use the object when the button Use is clicked
    public void UseObject()
    {
        objectCloud = colliderTriggeredInCloud.gameObject;
        objectFull = triggerManager.triggerInCloudToObjectFull[colliderTriggeredInCloud];

        cloud.SetActive(false);
        objectFull.SetActive(true);

        setObjectOnCharacter();
    }

    private void Update()
    {
        if (lerpObject)
        {
            //Move the object to the target transform
            if (objectCloud.tag == "Fruit")
            {
                objectFull.transform.position = Vector3.Lerp(lerpStart.position, character.transform.position, speed);
                objectFull.transform.rotation = Quaternion.Slerp(lerpStart.rotation, character.transform.rotation, speed);
            }
            else
            {
                objectFull.transform.position = Vector3.Lerp(lerpStart.position, lerpEnd.position, speed);
                objectFull.transform.rotation = Quaternion.Slerp(lerpStart.rotation, lerpEnd.localRotation, speed);
            }

            if (Vector3.Distance(objectFull.transform.position, lerpEnd.position) < Mathf.Epsilon)
                lerpObject = false;
        }
    }

    //Lerp the full object to the trap or the character
    public void setObjectOnCharacter()
    {
        Trap currentTrap = TriggerManager.instance.traps[TriggerManager.instance.triggerToTrapIndex[triggeredTrap.gameObject]];

        if (objectCloud.tag == "Fruit")
        {
            lerpStart = objectFull.transform;
            lerpEnd = character.transform;
            objectFull.transform.localScale = new Vector3(scale, scale, scale);
        } 
        else
        {
            lerpStart = objectFull.transform;
            lerpEnd = currentTrap.objectPos;
            objectFull.transform.localScale = lerpEnd.localScale;
        }

        lerpObject = true;
        StartCoroutine(objectAction(currentTrap));
    }

    //Do the action of the object
    IEnumerator objectAction(Trap trap)
    {
        yield return new WaitForSeconds(speed);

        if (objectCloud.tag == "Fruit")
        {
            if(life.lifeState < 4)
            {
                life.lifeState += 1;
            }
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
