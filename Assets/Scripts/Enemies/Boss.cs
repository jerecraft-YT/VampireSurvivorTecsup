using UnityEngine;

public sealed class Boss : Enemy
{
    [Tooltip("porcentaje de vida en donde si la vida del jefe baja de ese limite sera potenciado")]
    [SerializeField] private float percentToBost;
    [SerializeField] private float speedOnBost;
    [SerializeField] private float damageOnBost;
    private bool potenciado;

    private void Start()
    {
        //TakeDamage(1);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (potenciado) return;

        float porcentajeVida = Live / BaseStats.BaseLive;

        if (porcentajeVida < .5f)
        {
            potenciado = true;
            SetMoveSpeed(speedOnBost);
            //moveSpeed = speedOnBost;
        }
    }

    protected override void Attack(Entity entity)
    {
        
    }
}
