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
            Vector3 direction = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * leftJoystick.Vertical + new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * leftJoystick.Horizontal;
            transform.rotation = Quaternion.LookRotation(direction);
            player.MovePosition(player.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
