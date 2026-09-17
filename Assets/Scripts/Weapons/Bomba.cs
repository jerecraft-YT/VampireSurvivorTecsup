using UnityEngine;

public class Bomba : Weapon
{
    private const int DAÑO_BOMBA = 15;
    private const float CADENCIA_BOMBA = 3f;
    private const float RANGE_BOMBA = 3f;
    private const Element ELEMENT_BOMBA = Element.Fisico;

    public Bomba() : base(DAÑO_BOMBA, CADENCIA_BOMBA, RANGE_BOMBA, "Bomba", ELEMENT_BOMBA)
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

        foreach (var target in targets)
        {
            float distance = Vector3.Distance(origin.transform.position, target.transform.position);

            if (distance <= Range)
            {
                target.GetComponent<Entity>().TakeDamage(Daño);
            }
        }
    }
}
