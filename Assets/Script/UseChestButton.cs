using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseChestButton : MonoBehaviour
{
   public static GameObject fruit;

    public void UseChest()
    {
        Destroy(fruit);
    }
}
