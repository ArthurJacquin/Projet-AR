using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScale : MonoBehaviour
{
    [SerializeField] private Transform scene;

    public void ScaleScene(float scale)
    {
        scene.localScale = new Vector3(scale, scale, scale);
    }
}
