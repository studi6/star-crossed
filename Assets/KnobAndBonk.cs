using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobAndBonk : MonoBehaviour
{
    private Animator anim;
    private Coroutine attackCoroutine;

    void Start()
    {
        anim = GetComponent<Animator>();
        attackCoroutine = StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            float delay = Random.Range(2f, 3f);
            yield return new WaitForSeconds(delay);
            Attack();

            // Wait for the attack animation to finish
            float attackTime = anim.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(attackTime);

            // Return to idle state
            anim.SetInteger("state", 0);
        }
    }

    private void Attack()
    {
        // Set the animator parameter to trigger the attack animation
        anim.SetInteger("state", 1);
    }
}
