using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    private Animator anim;
    public GameObject otherObject;
    private Rigidbody rigidbody;
    public AudioSource punchSmack;

    // Start is called before the first frame update
    void Start()
    {
        anim = otherObject.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        punchSmack = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            rigidbody.isKinematic = false;
        }
        else
        {
            rigidbody.isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
            {
                punchSmack.Play();
                Debug.Log("Slapped the mfin enemy");
            }
        }
    }
}
