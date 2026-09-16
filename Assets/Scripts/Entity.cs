using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private int live;
    private float moveSpeed;

    [SerializeField] private BaseStats baseStats;

    protected virtual void Awake()
    {
        live = baseStats.BaseLive;
        moveSpeed = baseStats.BaseMoveSpeed;

        Debug.Log("Base stats Inicializada");
    }

    protected void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public virtual void TakeDamage(int damage)
    {
        live -= damage;

        Debug.Log("entity recibio daño");
    }

    protected abstract void Move();
    protected abstract void Attack(Entity entity);

    public BaseStats BaseStats => baseStats;

    public float MoveSpeed => moveSpeed;
    public float Live => live;
}
