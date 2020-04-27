using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Punch : MonoBehaviour
{
    private Animator anim;
    private bool punch;
    private float time;
    public GameObject hand;
    void Start()
    {
        anim = GetComponent<Animator>();
        hand.GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (time > 0.5f)
            {
                if (!punch)
                    punch = true;
                time = 0f;
            }
        }
        if (punch)
        {
            hand.GetComponent<SphereCollider>().enabled = true;
        }
        else
            hand.GetComponent<SphereCollider>().enabled = false;
        anim.SetBool("Punch", punch);
    }
    public void Reset()
    {
        punch = false;
        anim.SetBool("Punch", punch);
    }
}
