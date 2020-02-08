using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private Joystick leftJoystick;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody player;

    private void FixedUpdate()
    {
        Vector3 direction = -Vector3.right * leftJoystick.Vertical + Vector3.forward * leftJoystick.Horizontal;
        transform.rotation = Quaternion.LookRotation(direction);
        player.AddForce(direction * speed * Time.fixedDeltaTime);
    }
}
