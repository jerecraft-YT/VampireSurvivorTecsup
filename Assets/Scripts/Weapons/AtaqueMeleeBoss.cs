using UnityEngine;

public class AtaqueMeleeBoss : Weapon
{
    private const int DAÑO_ATAQUE_MELEE = 5;
    private const float CADENCIA_ATAQUE_MELEE = 2f;
    private const float RANGE_ATAQUE_MELEE = 2.5f;
    private const Element ELEMENT_ATAQUE_MELEE = Element.Fisico;

    public AtaqueMeleeBoss() : base(DAÑO_ATAQUE_MELEE, CADENCIA_ATAQUE_MELEE, RANGE_ATAQUE_MELEE, "AtaqueMeleeBoss", ELEMENT_ATAQUE_MELEE)
    {

    }

    public override void Attack(Entity origin, TargetType targetType)
    {
        GameObject[] targets;

        switch (targetType)
        {
            case TargetType.Player:
                targets = GameObject.FindGameObjectsWithTag("Player");
                break;
            case TargetType.Enemy:
                targets = GameObject.FindGameObjectsWithTag("Enemy");
                break;
            default:
                return;
        }

        GameObject enemigoCercano = null;

        float distanciaMinima = Range;

        foreach (var enemy in targets)
        {
            float distance = Vector3.Distance(origin.transform.position, enemy.transform.position);

            if (distance <= distanciaMinima)
            {
                distanciaMinima = distance;
                enemigoCercano = enemy;
            }
        }

        if (enemigoCercano != null)
        {
            enemigoCercano.GetComponent<Entity>().TakeDamage(Daño);
        }
    }
}
