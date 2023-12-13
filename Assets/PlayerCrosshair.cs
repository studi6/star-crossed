using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private float maxDistance = 10f;

    #region Singleton
    public static PlayerCrosshair instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        player = GameObject.FindWithTag("Player");
    }
    #endregion

    public Vector3 GetMousePosition()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        if (direction.magnitude > maxDistance)
        {
            direction = direction.normalized * 10f;
        }
        return direction;
    }

    private void Update()
    {
        Vector3 direction = GetMousePosition();
        transform.position = player.transform.position + new Vector3(direction.x, direction.y, 0f);
    }
}
