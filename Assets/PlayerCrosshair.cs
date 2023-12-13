using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] private GameObject player;
    private Transform playerTransform;
    private Transform crosshairTransform;
    [SerializeField] private float maxDistance = 10f;

    private void Start()
    {
        playerTransform = player.transform;
        crosshairTransform = transform;
    }

    private void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = targetPosition - playerTransform.position;
        if (direction.magnitude > maxDistance)
        {
            direction = direction.normalized * maxDistance;
        }
        crosshairTransform.position = playerTransform.position + new Vector3(direction.x, direction.y, 0f);
    }
}
