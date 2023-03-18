using UnityEngine;

public class PurpleEnemyMovement : EnemyMovement
{
    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (_enemy.Target == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, _enemy.Target.transform.position, _speed * Time.deltaTime);
    }
}