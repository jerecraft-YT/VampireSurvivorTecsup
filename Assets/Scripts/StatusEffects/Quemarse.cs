using UnityEngine;

public class Quemarse : StatusEffect
{
    private float damage;
    private float cooldown;
    private float timer;

    public Quemarse(Entity _target,float _damage, float _duration,float _cooldown) : base(_target, _duration)
    {
        damage = _damage;
        cooldown = _cooldown;
        timer = cooldown;
    }

    public override EffectType EffectType => EffectType.Quemarse;

    public override void UpdateEffect()
    {
        base.UpdateEffect();

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Debug.Log("daño por quemadura");
            target.TakeDamage(damage);
            timer = cooldown;
        }
    }

    protected override void OnRemoveEffect()
    {
        
    }
}
