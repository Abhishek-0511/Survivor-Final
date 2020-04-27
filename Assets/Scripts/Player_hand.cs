using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_hand : MonoBehaviour
{
    
public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<Enemy_dmg>().health -= 10f;
        }
    }
}
