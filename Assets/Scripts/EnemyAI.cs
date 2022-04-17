using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public NavMeshAgent nav;
    public int healthBar = 3;
    public Object self;
    private AudioSource enemyDeath;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        enemyDeath = GetComponent<AudioSource>();

        setRigidbodyState(true);
        setColliderState(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().enabled)
        {
            nav.SetDestination(player.position);
        }

        if (healthBar <= 0)
        {
            healthBar = 99;
            enemyDeath.pitch = Random.Range(0.8f, 1f);
            enemyDeath.Play();
            Death();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HandHitbox")
        {
            healthBar -= 1;
        }
    }
    private void Death()
    {
        Destroy(gameObject, 15f);
        GetComponent<Animator>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        setRigidbodyState(false);
        setColliderState(true);
    }

    void setRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

    }

    void setColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }
}
