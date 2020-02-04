using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager instance;

    [SerializeField] private GameObject[] trigger;
    [SerializeField] private GameObject[] trapObject;
    [SerializeField] private Transform[] objectPosOnTrap;
    [SerializeField] private GameObject[] solvingObject;
    [SerializeField] private TrapType[] trapTypes;

    [SerializeField] private BoxCollider[] triggersInCloud;
    [SerializeField] private GameObject[] objects;

    [HideInInspector]
    public List<Trap> traps;
    public Dictionary<Collider, GameObject> triggerInCloudToObjectFull;
    public Dictionary<GameObject, int> triggerToTrapIndex;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        for(int i = 0; i < trigger.Length; i++)
        {
            Trap t = new Trap();
            t.trigger = trigger[i];
            t.trapObject = trapObject[i];
            t.objectPos = objectPosOnTrap[i];
            t.solvingObject = solvingObject[i];
            t.type = trapTypes[i];
            traps.Add(t);

            triggerToTrapIndex.Add(trigger[i], i);
        }

        for(int i = 0; i < triggersInCloud.Length; i++)
        {
            triggerInCloudToObjectFull.Add(triggersInCloud[i], objects[i]);
        }
    }
}
