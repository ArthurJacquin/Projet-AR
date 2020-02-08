using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPeaks : MonoBehaviour
{
    [SerializeField] private LifeScript life;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damage")
        {
            life.looseLife();
            rb.MovePosition(rb.position + Vector3.back * speed);
        }
    }
}
