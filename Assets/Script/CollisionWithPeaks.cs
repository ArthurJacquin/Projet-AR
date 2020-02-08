using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPeaks : MonoBehaviour
{
    [SerializeField] private LifeScript life;
    [SerializeField] private CharacterController CharacterController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damage")
        {
            life.looseLife();
            CharacterController.Move(new Vector3(0, 0, -0.01f));
        }
    }
}
