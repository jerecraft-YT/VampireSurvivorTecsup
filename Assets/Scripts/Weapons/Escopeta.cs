using UnityEngine;

public class Escopeta : Pistola
{

    public Escopeta(int _daño, float _cadencia, int _range) : base(_daño, _cadencia, _range, "Escopeta")
    {
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
