using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public int lifeState = 3;

    [SerializeField] private GameObject lifeUi1;
    [SerializeField] private GameObject lifeUi2;
    [SerializeField] private GameObject lifeUi3;
    [SerializeField] private GameObject lifeUi4;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject replayUI;
    [SerializeField] private AudioSource gameOversound;
    [SerializeField] private AudioSource LooseLifesound;
    [SerializeField] private AudioSource GainLifesound;
    [SerializeField] private Animator anim;

    private bool inLife = true;
    
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            looseLife();
            print("looseLife");
            Debug.Log(lifeState);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            gainLife();
            print("gainLife");
            Debug.Log(lifeState);
        }
    }

    public void looseLife()
    {
        lifeState -= 1;
        LooseLifesound.Play();
        anim.Play("Damage");

        if (lifeState >= 1)
        {
            if (lifeState < 4)
            {
                lifeUi4.SetActive(false);
            }
            if (lifeState < 3)
            {
                lifeUi3.SetActive(false);
            }
            if (lifeState < 2)
            {
                lifeUi2.SetActive(false);
            }
            if (lifeState < 1)
            {
                lifeUi1.SetActive(false);
            }
        }
        else if(lifeState <= 0)
        {
            lifeUi1.SetActive(false);
            inLife = false;
            isDeadNow();
        }
    }
    
    public void gainLife()
    {
        if (lifeState < 4 && inLife == true)
        {
            lifeState += 1;
            GainLifesound.Play();
            anim.Play("Eat");
            
            if (lifeState >= 4)
            {
                lifeUi4.SetActive(true);
            }
            if (lifeState >= 3)
            {
                lifeUi3.SetActive(true);
            }
            if (lifeState >= 2)
            {
                lifeUi2.SetActive(true);
            }
            if (lifeState >= 1)
            {
                lifeUi1.SetActive(true);
            }
        }
    }

    public void isDeadNow()
    {
        if (inLife == false)
        {
            anim.Play("Dying");
            gameOverUI.SetActive(true);
            gameOversound.Play();
            replayUI.SetActive(true);
        }
    }
}
