using UnityEngine;

public enum EnemyState
{
    Idle,
    Follow,
    Attack
}

public abstract class Enemy : Entity
{
    [SerializeField] private float enemyXP;

    [SerializeField] private float distanceToFollow;
    [SerializeField] private float distanceToAttack;
    protected Entity target;
    protected float distanceToTarget;
    protected Vector3 dirMove;
    protected EnemyState enemyState;

    protected override void Update()
    {
        base.Update();

        if (target == null) return;

        GetTargetDistance();
        StateController();
    }

    protected override void Awake()
    {
        base.Awake();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>();
    }

    private void GetTargetDistance()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
    }

    protected abstract void Attack();

    protected virtual void StateController()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
                IdleController();
                break;
            case EnemyState.Follow:
                MoveController();
                break;
            case EnemyState.Attack:
                AttackController();
                break;
            default:
                break;
        }
    }

    protected virtual void IdleController()
    {
        if (distanceToTarget <= distanceToFollow)
        {
            enemyState = EnemyState.Follow;
        }
    }

    protected virtual void AttackController()
    {
        if (distanceToTarget > distanceToAttack)
        {
            enemyState = EnemyState.Follow;
        }
    }

    protected override void MoveController()
    {
        dirMove = (target.transform.position - transform.position).normalized;

        if (distanceToTarget <= distanceToAttack)
        {
            enemyState = EnemyState.Attack;
            return;
        }

        if (distanceToTarget <= distanceToFollow)
        {
            transform.position += dirMove * MoveSpeed * Time.deltaTime;
            return;
        }

        enemyState = EnemyState.Idle;
    }

    public float EnemyXP => enemyXP;
}
