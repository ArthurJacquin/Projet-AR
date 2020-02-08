using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private AudioSource victorySound;

    private void OnTriggerEnter(Collider other)
    {
        victoryUI.SetActive(true);
        replayButton.SetActive(true);
        victorySound.Play();
    }
}
