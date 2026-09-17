using UnityEngine;

public class Hielo : Weapon
{
    private const int DAÑO_HIELO = 5;
    private const float CADENCIA_HIELO = 1f;
    private const float RANGE_HIELO = 6f;
    private const Element ELEMENT_HIELO = Element.Hielo;

    public Hielo() : base(DAÑO_HIELO, CADENCIA_HIELO, RANGE_HIELO, "Hielo", ELEMENT_HIELO)
    {

    }

    public override void Attack(Entity origin, TargetType targetType)
    {

    }
}
