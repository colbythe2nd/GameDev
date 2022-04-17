using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandScript : MonoBehaviour
{
    private Animator anim;
    public GameObject otherObject;
    public GameObject winnerText;
    private Rigidbody rigidBody;
    private AudioSource punchSmack;
    private int smacksUntilWin;

    // Start is called before the first frame update
    void Start()
    {
        anim = otherObject.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        punchSmack = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(1).IsName("hit1"))
        {
            rigidBody.isKinematic = false;
        }
        else
        {
            rigidBody.isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (anim.GetCurrentAnimatorStateInfo(1).IsName("hit1"))
            {
                if (punchSmack == null) Debug.LogError("playerAudio is null on " + punchSmack.name);
                punchSmack.time = 0.1f;
                punchSmack.Play();
                smacksUntilWin++;

                if (smacksUntilWin >= 9)
                {
                    StartCoroutine(EndGame());
                }

            }
        }
    }

    IEnumerator EndGame()
    {
        winnerText.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Cursor.lockState = CursorLockMode.None;
    }
}
