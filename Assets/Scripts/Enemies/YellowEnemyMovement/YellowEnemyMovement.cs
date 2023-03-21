using UnityEngine;

public class YellowEnemyMovement : EnemyMovement
{
    [SerializeField] private float _distanceRange;

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (Enemy.Target == null)
            return;

        if (Mathf.Abs(Enemy.Target.transform.position.x-transform.position.x) > _distanceRange)
            transform.position = Vector2.MoveTowards(transform.position, Enemy.Target.transform.position, Speed * Time.deltaTime);
    }
}