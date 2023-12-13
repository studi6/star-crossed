using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Projectile")]
public class Projectile : ScriptableObject
{
    private GameObject bullet;
    int damage;
    float speed;
}