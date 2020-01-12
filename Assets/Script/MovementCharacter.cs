using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField]
    private Joystick leftJoystick;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject sol;

    private void FixedUpdate()
    {
        transform.localPosition += new Vector3(leftJoystick.Horizontal * speed, transform.localPosition.y, leftJoystick.Vertical * speed);
    }
}