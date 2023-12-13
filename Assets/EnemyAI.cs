using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private float distance;
    private Vector3 direction;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] float moveSpeed = 0.2f;  


    void Start()
    {
        player = SystemManager.instance.player;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= 5){
            direction = player.transform.position - transform.position;
            if (direction.x < 0)
                {
                    sr.flipX = false;
                }
            else
                {
                    sr.flipX = true;
                }
            rb.velocity = new Vector2(direction.x, direction.y).normalized * moveSpeed;
        }
            
    }
}
