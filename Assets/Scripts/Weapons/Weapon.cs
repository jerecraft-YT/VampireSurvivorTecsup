using System;
using UnityEngine;

public enum TargetType
{
    Player,
    Enemy,
}

public enum Element
{
    Fisico,
    Fuego,
    Hielo
}

public abstract class Weapon
{
    private float daño;
    private float cadencia;
    private string name;
    private float range;
    private Element element;

    private float multiplicadorDaño = 1f;

    public Weapon(float _daño, float _cadencia,float _range, string _name,Element _element)
    {
        daño = _daño;
        cadencia = _cadencia;
        name = _name;
        range = _range;
        element = _element;
    }

    public abstract void Attack(Entity origin, TargetType targetType);

    public void setDamageMultiplier(float value)
    {
        multiplicadorDaño = value;
    }

    public float Daño => daño * multiplicadorDaño;
    public float Cadencia => cadencia;
    public float Range => range;
    public string Name => name;
    public Element Element => element;
}
