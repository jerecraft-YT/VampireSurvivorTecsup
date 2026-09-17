using NUnit.Framework;
using UnityEngine;

public class Escopeta : Weapon
{
    private const int DAÑO_ESCOPETA = 3;
    private const float CADENCIA_ESCOPETA = 3f;
    private const float RANGE_ESCOPETA = 4f;
    private const Element ELEMENT_ESCOPETA = Element.Fisico;
    private const int MAX_ENEMY_TO_ATTACK = 5;

    //se hace asi para que cuando otra arma herede de esta pueda cambiar sus valores
    //por defecto y que luego la entidad al crearla no pueda cambiar eso
    protected Escopeta(int damage,float cadencia,float range,string name,Element element) : base(damage, cadencia, range, name, element)
    {

    }

    public Escopeta() : base(DAÑO_ESCOPETA, CADENCIA_ESCOPETA, RANGE_ESCOPETA, "Escopeta", ELEMENT_ESCOPETA)
    {

    }

    public override void Attack(Entity origin, TargetType targetType)
    {
        GameObject[] targets;

        switch (targetType)
        {
            case TargetType.Player:
                targets = GameObject.FindGameObjectsWithTag("Player");
                break;
            case TargetType.Enemy:
                targets = GameObject.FindGameObjectsWithTag("Enemy");
                break;
            default:
                return;
        }

        GameObject enemigoCercano = null;

        float distanciaMinima = Range;

        for (int i = 0; i < MAX_ENEMY_TO_ATTACK; i++)
        {
            foreach (var target in targets)
            {
                float distance = Vector3.Distance(origin.transform.position, target.transform.position);

                if (distance <= distanciaMinima)
                {
                    distanciaMinima = distance;
                    enemigoCercano = target;
                }
            }

            if (enemigoCercano != null)
            {
                Entity target = enemigoCercano.GetComponent<Entity>();

                target.TakeDamage(Daño);

                PostAttack(target);
            }
        }
    }

    protected virtual void PostAttack(Entity target)
    {

    }
}
