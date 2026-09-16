public class WeaponStats
{
    private int daño;
    private float cadencia;
    private string name;
    private float proyectilSpeed;

    public WeaponStats(int _daño, float _cadencia, float _proyectilSpeed, string _name)
    {
        daño = _daño;
        cadencia = _cadencia;
        proyectilSpeed = _proyectilSpeed;
        name = _name;
    }

    public int Daño => daño;
    public float Cadencia => cadencia;
    public string Name => name;
    public float ProyectilSpeed => proyectilSpeed;
}
