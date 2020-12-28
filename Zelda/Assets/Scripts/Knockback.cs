using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    //knockback force
    public float thrust;
    //knock force lasting time
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                //set eenmy state to stagger
                enemy.GetComponent<Enemy>().currentState=EnemyState.stagger;
                //calcultae difference between enemy and player to apply force on it
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                Debug.Log(difference);
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            //let enemy move in knockback direction for a time and stop
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            //set enemystate back to idle
            enemy.GetComponent<Enemy>().currentState=EnemyState.idle;
        }
    }
}
