﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private AudioSource victorySound;
    [SerializeField] private AudioSource ambianceSound;
    [SerializeField] private Animator victoryanim;

    private void OnTriggerEnter(Collider other)
    {
        victoryanim.SetBool("Victory", true);

        victoryUI.SetActive(true);
        replayButton.SetActive(true);
        victorySound.Play();
        ambianceSound.Stop();
    }
}
