using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    public abstract void Move();
}