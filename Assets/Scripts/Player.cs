using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Entity
{
    [Header("Referencias para movimiento")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference attackAction;

    private Weapon actualWeapon;

    private Vector2 dirMove;
    private Rigidbody2D rb;

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();

        SetActionReferences();

        actualWeapon = new Pistola(10,10f,3f,"Pistola");
    }

    private void SetActionReferences()
    {
        moveAction.action.performed += OnMove;
        moveAction.action.canceled += OnMove;

        attackAction.action.performed += OnAttack;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        dirMove = ctx.ReadValue<Vector2>();
    }

    private void OnAttack(InputAction.CallbackContext ctx)
    {
        FindEnemies();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        rb.linearVelocity = dirMove * MoveSpeed;
    }

    private void FindEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance <= actualWeapon.Range)
            {
                Entity entity = enemy.GetComponent<Enemy>();

                Attack(entity);
            }
        }
    }

    protected override void Attack(Entity entity)
    {
        entity.TakeDamage(actualWeapon.Daño);
    }
}
