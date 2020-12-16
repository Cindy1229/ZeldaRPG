using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Smash()
    {
        //animator change the animation to pot destroy and not loops
        animator.SetBool("smash", true);
        //start a coroutine and eventually deactivate the game object
        StartCoroutine(breakCo());
    }

    IEnumerator breakCo()
    {
        //deactive the pot and remove from the map
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}
