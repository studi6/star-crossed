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
    [SerializeField] private GameObject basicLazer;
    [SerializeField] private GameObject bullet;

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
                anim.SetInteger("state", 0); // Idle state
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
                    StartCoroutine(AttackPattern());
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
                // }
            }
            else
            {
                anim.SetInteger("state", 0); // Set idle state if target is null
            }
        }
    }

    private IEnumerator AttackPattern() {
        switch(attackStage % 12){
            case 3:
                yield return StartCoroutine(LazerBeam());
                break;
            case 7:
                yield return StartCoroutine(JumpAttack());
                break;
            case 11:
                yield return StartCoroutine(BulletCircle());
                break;
            default: 
                yield return StartCoroutine(BasicAttack());
                break;
        }
        isAttacking = false;
        attackStage += 1;
    }

    private IEnumerator LazerBeam() {
        Debug.Log("attack 1"); // console log check
        // TODO
        yield return null;
    }

    private IEnumerator JumpAttack() {
        Debug.Log("attack 2"); // console log check
        // TODO
        yield return null;
    }

    private IEnumerator BulletCircle() {
        yield return new WaitForSeconds(0.3f);

        Vector3[] directions = {
            Vector3.up, // North
            (Vector3.up + Vector3.right).normalized, // Northeast
            Vector3.right, // East
            //(Vector3.down + Vector3.right).normalized, // Southeast
            //Vector3.down ,// South
            //(Vector3.down + Vector3.left).normalized, // Southwest
            Vector3.left, // West
            (Vector3.up + Vector3.left).normalized // Northwest
        };

        // Instantiate bullets for each direction
        foreach (Vector3 direction in directions)
        {
            GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity);
            projectile.transform.right = direction;
            projectile.GetComponent<Rigidbody2D>().AddForce(direction * 20f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.00001f);
        }
    }

    private IEnumerator BasicAttack() {
        yield return new WaitForSeconds(1.5f);

        Vector3 direction = (target.position - transform.position).normalized;
        GameObject projectile = Instantiate(basicLazer, transform.position, Quaternion.LookRotation(Vector3.forward, direction));
        projectile.GetComponent<Rigidbody2D>().AddForce(direction * 20f, ForceMode2D.Impulse);
    }
}
