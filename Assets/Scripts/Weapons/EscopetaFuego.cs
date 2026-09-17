using UnityEngine;

public class EscopetaFuego : Escopeta
{
    private const int DAÑO_ESCOPETA_FUEGO = 3;
    private const float CADENCIA_ESCOPETA_FUEGO = 3f;
    private const float RANGE_ESCOPETA_FUEGO = 4f;
    private const Element ELEMENT_ESCOPETA_FUEGO = Element.Fuego;
    private const float DAÑO_QUEMADURA = 1;
    private const float DURACION_QUEMADURA = 2f;
    private const float COOLDOWN_QUEMAR = 0.5f;

    public EscopetaFuego() : base(DAÑO_ESCOPETA_FUEGO, CADENCIA_ESCOPETA_FUEGO, RANGE_ESCOPETA_FUEGO, "Escopeta de fuego", ELEMENT_ESCOPETA_FUEGO)
    {

    }

    protected override void PostAttack(Entity target)
    {
        target.EffectsController.AddEffect(new Quemarse(target, DAÑO_QUEMADURA, DURACION_QUEMADURA, COOLDOWN_QUEMAR));
    }
}
