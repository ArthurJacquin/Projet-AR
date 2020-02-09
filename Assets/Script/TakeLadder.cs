using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLadder : MonoBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField]  public GameObject player;
    [SerializeField]  public GameObject playerAnimator;
    static public int col;

    public void climbLadder()
    {
        StartCoroutine(waitForAnim(3.5f));
    }

    private IEnumerator waitForAnim(float time)
    {
        if (col == 1)
        {
            player.transform.localPosition = new Vector3(-0.8f, 0.115f, -0.27f);
            player.transform.rotation = Quaternion.LookRotation(Vector3.right);
            player.transform.GetChild(0).rotation = Quaternion.LookRotation(Vector3.right);

            anim.speed = 2f;
            anim.Play("Climbing");

            yield return new WaitForSeconds(time);
            anim.Play("Idle");
            playerAnimator.transform.localPosition = new Vector3(0f, 0f, 0f);
            player.transform.localPosition = new Vector3(-0.6f, 0.2533f, -0.26f);
            player.transform.rotation = Quaternion.LookRotation(Vector3.right);
            player.transform.GetChild(0).rotation = Quaternion.LookRotation(Vector3.right);
            
        }
        else if (col == 3)
        {
            player.transform.localPosition = new Vector3(-0.703f, 0.259f, -0.061f);
            player.transform.rotation = Quaternion.LookRotation(Vector3.right);
            player.transform.GetChild(0).rotation = Quaternion.LookRotation(Vector3.right);
            anim.speed = 2f;
            anim.Play("ClimbingBack");

            yield return new WaitForSeconds(time);
            anim.Play("Idle");
            playerAnimator.transform.localPosition = new Vector3(0f, 0f, 0f);
            player.transform.localPosition = new Vector3(-0.7946f, 0.115f, -0.0612f);
            player.transform.rotation = Quaternion.LookRotation(Vector3.right);
            player.transform.GetChild(0).rotation = Quaternion.LookRotation(Vector3.right);
            
        }

        else if (col == 2)
        {
            player.transform.localPosition = new Vector3(0.895f, 0.265f, -1.424f);
            player.transform.rotation = Quaternion.LookRotation(-Vector3.forward);
            player.transform.GetChild(0).rotation = Quaternion.LookRotation(-Vector3.forward);
            anim.speed = 2f;
            anim.Play("ClimbingBack");

            yield return new WaitForSeconds(time);
            anim.Play("Idle");
            playerAnimator.transform.localPosition = new Vector3(0f, 0f, 0f);
            player.transform.localPosition = new Vector3(0.892f, 0.115f, -1.296f);
            player.transform.rotation = Quaternion.LookRotation(-Vector3.forward);
            player.transform.GetChild(0).rotation = Quaternion.LookRotation(-Vector3.forward);
        }
        else if (col == 4)
        {
            player.transform.localPosition = new Vector3(0.675f, 0.1097f, -1.538f);
            player.transform.rotation = Quaternion.LookRotation(Vector3.right);
            player.transform.GetChild(0).rotation = Quaternion.LookRotation(Vector3.right);
            anim.speed = 2f;
            anim.Play("Climbing");
            yield return new WaitForSeconds(time);
            anim.Play("Idle");
            playerAnimator.transform.localPosition = new Vector3(0f, 0f, 0f);
            player.transform.localPosition = new Vector3(0.846f, 0.2621f, -1.5353f);
            player.transform.rotation = Quaternion.LookRotation(Vector3.right);
            player.transform.GetChild(0).rotation = Quaternion.LookRotation(Vector3.right);
        }

    }
}
