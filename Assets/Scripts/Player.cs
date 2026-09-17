using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    [Header("Referencias para movimiento")]
    [SerializeField] private InputActionReference moveAction;

    private Weapon actualWeapon;
    private Vector2 dirMove;
    private float timeAttack;

    protected override void Awake()
    {
        base.Awake();

        SetActionReferences();

        actualWeapon = new EscopetaFuego();

        timeAttack = actualWeapon.Cadencia;
    }

    private void SetActionReferences()
    {
        moveAction.action.performed += OnMove;
        moveAction.action.canceled += OnMove;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        dirMove = ctx.ReadValue<Vector2>();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    protected override void Update()
    {
        base.Update();

        MoveController();
        WeaponController();
    }

    private void WeaponController()
    {
        if (actualWeapon == null) return;

        timeAttack -= Time.deltaTime;

        if (timeAttack <= 0)
        {
            Attack();
            timeAttack = actualWeapon.Cadencia;
        }
    }

    protected override void MoveController()
    {
        transform.position += (Vector3)dirMove * MoveSpeed * Time.deltaTime;
    }

    private void Attack()
    {
        actualWeapon.Attack(this,TargetType.Enemy);
    }

    public Weapon ActualWeapon => actualWeapon;
}
