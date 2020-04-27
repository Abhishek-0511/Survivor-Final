using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    public float distance = 3f;
    private bool stood = false;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("standanim", 8.267f);
        var navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        var navAgent = GetComponent<NavMeshAgent>();
        animator.SetFloat("speed", navAgent.velocity.magnitude);
        if (Vector3.Distance(player.transform.position, transform.position) <= 30f)
        {
            transform.LookAt(player.transform);

            if (stood)
            {
               

                if (Vector3.Distance(gameObject.transform.position, player.transform.position) < distance)
                {
                    navAgent.isStopped = true;
                    if (!animator.GetBool("attack"))
                        animator.SetBool("attack", true);
                }
                else
                {
                    animator.SetBool("attack", false);
                    navAgent.SetDestination(player.transform.position);
                    navAgent.isStopped = false;
                }
            }
        }
        else
        {
          
            navAgent.isStopped = true;
        }
    }
 

    void standanim()
    {
        stood = true;
    }

    void punchanim()
    {
        animator.SetBool("attack",true);
    }
}
