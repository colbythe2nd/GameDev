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

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);

        if (healthBar <= 0)
        {
            Destroy(self);
        }
    }

/*    void OnTriggerEnter(Collider other)
    {
        //Note: we use colliders here, not collisions

    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HandHitbox")
        {
            Debug.Log("Got slapped lmao");
            healthBar -= 1;
        }
    }

    /*    void OnCollisionEnter(Collision collision)
        {
            Debug.Log("IM COLLIDING");
            Debug.Log(collision.gameObject.name);
            //Check for a match with the specified name on any GameObject that collides with your GameObject
            if (collision.gameObject.name == "HandHitbox")
            {
                //If the GameObject's name matches the one you suggest, output this message in the console
                Debug.Log("Do something here");
            }

            //Check for a match with the specific tag on any GameObject that collides with your GameObject
            if (collision.gameObject.tag == "HandHitbox")
            {
                //If the GameObject has the same tag as specified, output this message in the console
                Debug.Log("Do something else here");
            }
        }*/
}
