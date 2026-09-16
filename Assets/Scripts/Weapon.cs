using System;
using UnityEngine;

public abstract class Weapon
{
    private int daño;
    private float cadencia;
    private string name;
    private float range;

    public Weapon(int _daño, float _cadencia,float _range, string _name)
    {
        daño = _daño;
        cadencia = _cadencia;
        name = _name;
        range = _range;
    }

    public abstract void Shoot();

    public int Daño => daño;
    public float Cadencia => cadencia;
    public float Range => range;
    public string Name => name;
}
