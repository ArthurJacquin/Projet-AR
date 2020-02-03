using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapType
{
    Place,
    Open,
    Destroy
}

public class Trap : MonoBehaviour
{
    public BoxCollider trigger;
    public Transform objectPos;
    public Transform solvingObject;
    public TrapType type;
}
