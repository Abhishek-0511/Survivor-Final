using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_dmg : MonoBehaviour
{
    public float health;
    public GameObject healthbar;
    float y, z;
    private Animator anim;
    void Start()
    {
        health = 100f;
        y = healthbar.transform.localScale.y;
        z = healthbar.transform.localScale.z;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthbar)
        healthbar.transform.localScale = new Vector3(health / 100, y, z);
        if (health <= 0f)
        {
            Destroy(healthbar);
            anim.SetTrigger("Dead");
            Destroy(this.gameObject, 3f);
        }
    }
}
