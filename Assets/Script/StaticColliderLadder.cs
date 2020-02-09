using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticColliderLadder : MonoBehaviour
{
    [SerializeField] public int col = 0;
    [SerializeField] public GameObject useButton;

    public void OnTriggerEnter(Collider other)
    {
        useButton.SetActive(true);
        col = col;
    }
    public void OnTriggerExit(Collider other)
    {
        useButton.SetActive(false);
    }
}
