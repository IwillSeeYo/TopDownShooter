using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class YellowEnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Blast _blast;
    [SerializeField] private float _delay;

    private Enemy _enemy;
    private float _lastAttackTime;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _lastAttackTime = _delay;
    }

    private void Update()
    {
        if (_lastAttackTime < 0)
        {
            Attack();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {

        if (_enemy.Target == null)
            return;

        Vector3 targetPosition = _enemy.Target.transform.position;
        Vector3 shootPosition = _enemy.transform.position;
        Vector3 direction = targetPosition - shootPosition;

        var bullet = Instantiate(_blast, transform.position, Quaternion.identity);

        bullet.transform.right = direction;
    }
}