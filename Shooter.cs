using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    public GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void SetLaneSpawner()
    {
        
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        //Debug.Log("spanwers are null? " + spawners == null);
        foreach (AttackerSpawner spawner in spawners)
        {
            float absDiff = Mathf.Abs(spawner.transform.position.y - transform.position.y);
            bool isCloseEnough = (absDiff <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            //Debug.Log("Shoot Pew Pew");
            animator.SetBool("isAttacking", true);
        }
        else
        {
            //Debug.Log("Sit and wait");
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerInLane()
    {
        //if my lane spawner child count less than or equal to 0
        //return false;
        //Debug.Log("myLaneSpawer is null? " + myLaneSpawner == null);
        if (myLaneSpawner && myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
        
    }
}
