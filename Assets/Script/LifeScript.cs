using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public int lifeState = 3;

    [SerializeField] private GameObject lifeUi;
    private bool inLife = true;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("loose life");
            lifeState -= 1;
        }
    }
}
