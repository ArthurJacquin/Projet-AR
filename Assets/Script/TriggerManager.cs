using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager instance;

    [SerializeField] private BoxCollider[] trigger;
    [SerializeField] private Transform[] objectPosOnTrap;
    [SerializeField] private Transform[] solvingObject;
    [SerializeField] private TrapType[] trapTypes;

    private List<Trap> traps;

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
            t.objectPos = objectPosOnTrap[i];
            t.solvingObject = solvingObject[i];
            t.type = trapTypes[i];
            traps.Add(t);
        }
    }
}
