using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        //if this is a gravestone then start the jump animation
        if (otherCollider.GetComponent<Gravestone>()) {
            //change the fox animator jumpTrigger
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }

        //if this is another defender
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
