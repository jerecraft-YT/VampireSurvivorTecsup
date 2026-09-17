using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected float live;
    private float moveSpeed;
    private float moveSpeedMultiplier = 1f;

    [SerializeField] private BaseStats baseStats;
    private StatusEffectsController effectsController;

    protected virtual void Awake()
    {
        if (baseStats == null)
        {
            Debug.LogError("Base stats no asignado");
            return;
        }

        live = baseStats.BaseLive;
        moveSpeed = baseStats.BaseMoveSpeed;

        effectsController = new();

        Debug.Log("Base stats Inicializada");
    }

    protected virtual void Update()
    {
        effectsController.ControllerUpdate();
    }

    protected void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void SetMoveSpeedMultiplier(float value)
    {
        moveSpeedMultiplier = value;
    }

    public virtual void TakeDamage(float damage)
    {
        live -= damage;

        Debug.Log("entity recibio daño");

        if (live <= 0) Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void MoveController();

    public BaseStats BaseStats => baseStats;
    public StatusEffectsController EffectsController => effectsController;
    public float MoveSpeed => moveSpeed * moveSpeedMultiplier;
    public float Live => live;

}
