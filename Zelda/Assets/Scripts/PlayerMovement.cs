using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}
public class PlayerMovement : MonoBehaviour
{
    // Player movement speed
    public float speed;
    // Our rigidbody, used to set position
    private Rigidbody2D myRigidBody;
    //Change in position in 2d space on every key press
    private Vector3 change;
    // Used to call our animation pictures
    private Animator animator;
    //player current state
    PlayerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState=PlayerState.walk;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //initial animation facing down
        animator.SetFloat("moveX",0);
        animator.SetFloat("moveY",-1);
        


    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxis("Horizontal");
        change.y = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack)
        {
            //when attack key space is pressed begin a attack subroutine
            StartCoroutine(AttackCo());
        }
        // Debug.Log(change);
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }


    }

    private IEnumerator AttackCo()
    {
        //set the state to attack state
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        //end attacking and return walk;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            // Set parameters in animator to indicate a change in picture displayed
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("walking", true);

        }
        else
        {
            animator.SetBool("walking", false);
        }
    }
    void MoveCharacter()
    {
        //normalize change so player is not moving diagonally too fast
        change.Normalize();
        // set the postion of our rigid body by change in 2d space +our original position
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
