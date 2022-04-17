using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAnimator : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 0.5f;
    private AudioSource punchWoosh;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.4f;
    public GameObject dialogueAwait;

    private void Start()
    {
        anim = GetComponent<Animator>();
        punchWoosh = GetComponent<AudioSource>();
    }
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.1f && anim.GetCurrentAnimatorStateInfo(1).IsName("hit1"))
        {
            anim.SetBool("hit1", false);
        }
        /*        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
                {
                    anim.SetBool("hit2", false);
                }
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
                {
                    anim.SetBool("hit3", false);
                    noOfClicks = 0;
                }*/


        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();

            }
        }
    }

    void OnClick()
    {
        if (!dialogueAwait.activeSelf)
        {
            lastClickedTime = Time.time;
            if (noOfClicks == 0)
            {
                if (anim.GetBool("Grounded"))
                {
                    anim.SetBool("hit1", true);
                    punchWoosh.pitch = Random.Range(0.9f, 1.1f);
                    punchWoosh.Play(0);
                    noOfClicks = 1;
                }
            }
        }

    }
}