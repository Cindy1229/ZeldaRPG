using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    
    //Rigid body 2d
    private Rigidbody2D myRigidbody;
    //Player position
    public Transform target;
    //chase range
    public float chaseRadius;
    //attack range
    public float attackRadius;
    //Enemy go back to home position if player is out of range
    public Transform homePosition;

    // Start is called before the first frame update
    void Start()
    {
        //set initial state to idle
        currentState=EnemyState.idle;
        //get rigidbosy of log
        myRigidbody=GetComponent<Rigidbody2D>();
        //get player
        target = GameObject.FindWithTag("Player").transform;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState==EnemyState.idle || currentState==EnemyState.walk && currentState!=EnemyState.stagger) {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                //change the state to walking
                ChangeState(EnemyState.walk);
            }
            

        }
    }

    private void ChangeState(EnemyState newState){
        if(currentState!=newState){
            currentState=newState;
        }
    }
}
