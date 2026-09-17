using UnityEngine;

public sealed class Boss : Enemy
{
    private Weapon actualWeapon;

    [Header("cosas boss")]

    [Tooltip("porcentaje de vida en donde si la vida del jefe baja de ese limite sera potenciado")]
    [SerializeField] private float percentToBost;
    [SerializeField] private float speedOnBost;
    [SerializeField] private float damageMultiplierOnBost;
    private bool potenciado;
    private float timeAttack;

    protected override void Awake()
    {
        base.Awake();

        actualWeapon = new AtaqueMeleeBoss();
    }

    protected override void Update()
    {
        base.Update();

        WeaponController();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if (potenciado) return;

        float porcentajeVida = Live / BaseStats.BaseLive;

        if (porcentajeVida < percentToBost)
        {
            potenciado = true;
            SetMoveSpeed(speedOnBost);
            actualWeapon.setDamageMultiplier(damageMultiplierOnBost);
        }
    }

    protected override void Attack()
    {
        actualWeapon.Attack(this, TargetType.Player);
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
}
