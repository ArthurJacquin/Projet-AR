using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerInitialPosition;
    
    //Mouvement parameters
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

    private void Awake()
    {
        moveDir = Vector3.zero;
        playerInitialPosition = player.transform.position;
    }

    void FixedUpdate()
    {
        horizontalInput = leftJoystick.Horizontal;
        verticalInput = leftJoystick.Vertical;

        moveDirForward = transform.forward * verticalInput;
        moveDirSide = transform.right * horizontalInput;
        moveDir += (moveDirForward + moveDirSide).normalized;

        dis = moveDir * speed * Time.deltaTime;

        MovementUpdate();
    }

    private void MovementUpdate()
    {
        if (isMoving())
            controller.Move(dis);
        else
            moveDir = Vector3.zero;
    }

    private bool isMoving()
    {
        return horizontalInput != 0 || verticalInput != 0;
    }
}
