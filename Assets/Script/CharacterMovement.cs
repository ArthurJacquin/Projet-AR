using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Joystick leftJoystick;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 moveDir = Vector3.zero;
    private Vector3 dis = Vector3.zero;
    private Vector3 moveDirForward = Vector3.zero;
    private Vector3 moveDirSide = Vector3.zero;
    private float horizontalInput = 0.0f;
    private float verticalInput = 0.0f;
    public bool Ddebug = true;

    private void Awake()
    {
        moveDir = Vector3.zero;
    }

    void FixedUpdate()
    {
        horizontalInput = leftJoystick.Horizontal;
        verticalInput = leftJoystick.Vertical;
        moveDirForward = transform.forward * verticalInput;
        moveDirSide = transform.right * horizontalInput;
        moveDir += (moveDirForward + moveDirSide).normalized;
        dis = moveDir * speed * Time.deltaTime;
        if (Ddebug) Debug.Log(moveDir);
        controller.Move(dis);
        
    }
}
