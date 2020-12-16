using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
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
        //get player
        target = GameObject.FindWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        }
    }
}
