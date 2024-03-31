using System.Collections;
using UnityEngine;

public class KnobAndBonk : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;
    public Transform target;
    public float moveSpeed = 2.5f;
    private bool isAttacking = false;
    private int attackStage = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(AttackLoop());
    }

    void Update()
    {
        if (target != null) {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (!isAttacking && direction.magnitude > 0.1f){
                anim.SetInteger("state", 2); // Idle state
            } else {
                // maintains attack pattern
                attackPattern();
                attackStage += 1;
            }
        }
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            isAttacking = false;

            // Wait for idle time (2-3 seconds)
            float idleTime = Random.Range(2f, 3f);
            yield return new WaitForSeconds(idleTime);

            if (target != null)
            {
                // Move towards the player during idle time
                Vector3 direction = (target.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
                sr.flipX = ((direction.x > 0) ? true : false);

                // Set chase state while moving towards the player
                anim.SetInteger("state", 2);

                // Wait until idle time ends or the player is close enough to attack
                float timer = 0f;
                while (timer < idleTime && direction.magnitude > 1.5f)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }

                // // Check if the player is within attack range
                // if (direction.magnitude <= 1.5f)
                // {
                    isAttacking = true;
                    // Set attack state
                    anim.SetInteger("state", 1);
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
                // }
            }
            else
            {
                anim.SetInteger("state", 0); // Set idle state if target is null
            }
        }
    }

    private void attackPattern() {
        switch(attackStage % 12){
            case 3:
                lazerBeam();
                break;
            case 7:
                jumpAttack();
                break;
            case 11:
                bulletCircle();
                break;
            default: 
                basicAttack();
                break;
        }
    }

    private void lazerBeam() {
        Debug.Log("attack 1"); // console log check
        // TODO
    }

    private void jumpAttack() {
        Debug.Log("attack 2"); // console log check
        // TODO
    }

    private void bulletCircle() {
        Debug.Log("attack 3"); // console log check
        // TODO
    }

    private void basicAttack() {
        Debug.Log("basic attack"); // console log check
        // TODO
    }
}
