using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;
    GameObject currentTarget;
    private AudioSource chewSound;
    private void Start()
    {
        chewSound = GetComponent<AudioSource>();
    }

    /*
     Awake: This function is always called before any Start functions and
     also just after a prefab is instantiated.
     (If a GameObject is inactive during start up Awake is not called until it is made active.)
     */

    private void Awake()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController)
        {
            levelController.AttackerSpawned();
        }

    }
    /*
    OnDestroy: This function is called after all frame updates for the last frame of the object’s existence
    (the object might be destroyed in response to Object.Destroy or at the closure of a scene).
    */
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController)
        {
            levelController.AttackerKilled();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
        if (transform.position.x < -2)
        {
            Destroy(gameObject);
        }
        
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;

    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }
       
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {

            health.DealDamage(damage);
        }
    }
    //used for animation event
    public void PlayChewSound() {

        chewSound.Play();
    }
    //used for other script
    public void StopChewSound() {

        if (chewSound != null) {
            chewSound.Stop();
        }
        
    }

       

}
