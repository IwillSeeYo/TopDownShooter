using UnityEngine;

[RequireComponent(typeof(Enemy))]

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected Enemy Enemy;

    private void Start()
    {
        Enemy = GetComponent<Enemy>();
    }

    public abstract void Move();
}