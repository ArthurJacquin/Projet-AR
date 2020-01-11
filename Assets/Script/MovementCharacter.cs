using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField]
    private Joystick leftJoystick;
    [SerializeField]
    private float speed;

    private void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(leftJoystick.Horizontal * speed,
                                         0.0f,
                                         leftJoystick.Vertical * speed);
    }
}