using UnityEngine;

public enum EffectType
{
    Congelarse,
    Quemarse
}

public abstract class StatusEffect
{
    protected Entity target;
    protected float duration;

    public StatusEffectsController effectsController;

    public StatusEffect(Entity _target, float _duration)
    {
        target = _target;
        duration = _duration;
    }

    public virtual void UpdateEffect()
    {
        duration -= Time.deltaTime;

        if (duration <= 0)
        {
            OnRemoveEffect();
            effectsController.RemoveEffect(this);
            
        }
    }

    protected abstract void OnRemoveEffect();

    public abstract EffectType EffectType { get; }

    public bool Termino => duration <= 0;
    
}
