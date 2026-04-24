using UnityEngine;

public class ZeusAttack : MonoBehaviour
{
    public GameObject lightningProjectile;
    public Transform shootPoint;
    public float shootInterval = 2f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        InvokeRepeating(nameof(Shoot), 1f, shootInterval);
    }

    void Shoot()
    {
        if (player == null || lightningProjectile == null || shootPoint == null) return;

        GameObject proj = Instantiate(lightningProjectile, shootPoint.position, Quaternion.identity);

        Vector2 dir = (player.position - shootPoint.position).normalized;

        proj.GetComponent<Rigidbody2D>().linearVelocity = dir * 6f;
    }
}