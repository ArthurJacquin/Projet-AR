using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapType
{
    Place,
    PlaceAndDisable,
    Open,
    Destroy
}

public class Trap : MonoBehaviour
{
    public GameObject trigger;
    public Transform objectPos;
    public GameObject solvingObject;
    public GameObject trapObject;
    public TrapType type;
}
