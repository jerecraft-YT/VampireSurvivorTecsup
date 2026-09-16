using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Proyectil : MonoBehaviour
{
    private Rigidbody2D rb;

    /// <summary>
    /// inicializacion del proyectil del arma, solicita que le mandes la informacion necesaria para moverse
    /// </summary>
    public void Initialize(Vector2 dir, WeaponStats weaponStats,float timeLife)
    {
        rb.linearVelocity = dir * weaponStats.ProyectilSpeed;

        Destroy(gameObject, timeLife);
    }
}
