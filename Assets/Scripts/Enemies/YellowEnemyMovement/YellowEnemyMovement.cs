using UnityEngine;

public class YellowEnemyMovement : EnemyMovement
{
    [SerializeField] private float _distanceRange;

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (_enemy.Target == null)
            return;

        if (Mathf.Abs(_enemy.Target.transform.position.x-transform.position.x) > _distanceRange)
            transform.position = Vector2.MoveTowards(transform.position, _enemy.Target.transform.position, _speed * Time.deltaTime);
    }
}