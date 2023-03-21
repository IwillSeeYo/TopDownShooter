using UnityEngine;

public class PurpleEnemyMovement : EnemyMovement
{
    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (Enemy.Target == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, Enemy.Target.transform.position, Speed * Time.deltaTime);
    }
}