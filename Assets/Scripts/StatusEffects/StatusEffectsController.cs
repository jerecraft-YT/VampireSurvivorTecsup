using System;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectsController
{
    private List<StatusEffect> statusEffects = new();

    public void ControllerUpdate()
    {
        foreach (var effect in statusEffects)
        {
            effect.UpdateEffect();
        }
    }

    public void RemoveEffect(StatusEffect effect)
    {
        statusEffects.Remove(effect);
    }

    public void AddEffect(StatusEffect newEffect)
    {
        StatusEffect effectToRemove = null;

        //limitacion para no tener el mismo efecto duplicado
        foreach(var effect in statusEffects)
        {
            if (effect.EffectType == newEffect.EffectType)
            {
                effectToRemove = effect;
                break;
            }
        }

        if (effectToRemove != null)
        {
            statusEffects.Remove(effectToRemove);
        }

        statusEffects.Add(newEffect);
        newEffect.effectsController = this;
    }
}
