using UnityEngine;

public class Zombie : Enemy
{
    private Weapon actualWeapon;
    private float timeAttack;

    protected override void Awake()
    {
        base.Awake();

        actualWeapon = new AtaqueMelee();
    }

    protected override void Update()
    {
        base.Update();

        WeaponController();
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
