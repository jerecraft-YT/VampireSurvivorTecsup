public class Congelarse : StatusEffect
{
    public Congelarse(Entity target,float duracion,float multiplicadorVelocidad) : base(target, duracion)
    {
        target.SetMoveSpeedMultiplier(multiplicadorVelocidad);
    }

    public override EffectType EffectType => EffectType.Congelarse;

    protected override void OnRemoveEffect()
    {
        target.SetMoveSpeedMultiplier(1f);
    }
}
