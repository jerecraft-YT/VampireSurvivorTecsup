using UnityEngine;

public class VaritaMagica : Weapon
{
    private const int DAÑO_VARITA_MAGICA = 8;
    private const float CADENCIA_VARITA_MAGICA = 0.3f;
    private const float RANGE_VARITA_MAGICA = 8f;
    private const Element ELEMENT_VARITA_MAGICA = Element.Fuego;

    public VaritaMagica() : base(DAÑO_VARITA_MAGICA, CADENCIA_VARITA_MAGICA, RANGE_VARITA_MAGICA, "Varita Magica", ELEMENT_VARITA_MAGICA)
    {

    }

    public override void Attack(Entity origin, TargetType targetType)
    {

    }
}
