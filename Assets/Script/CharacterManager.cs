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
        if(leftJoystick.Vertical != 0 && leftJoystick.Horizontal != 0)
        {
            Vector3 direction = -Vector3.right * leftJoystick.Vertical + Vector3.forward * leftJoystick.Horizontal;
            transform.rotation = Quaternion.LookRotation(direction);
            player.MovePosition(player.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
