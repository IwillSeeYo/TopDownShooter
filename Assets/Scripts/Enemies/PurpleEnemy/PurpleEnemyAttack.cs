using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PurpleEnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Animator _animator;
    private Coroutine _coroutine;
    private bool _canAttack;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _canAttack = true;
            _coroutine = StartCoroutine(WaitForAttack(player));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _canAttack= false;
            StopCoroutine(_coroutine);
        }
    }

    private void Attack(Player target)
    {
        if (target == null)
            return;

        target.ApplyDamage(_damage);
    }

    private IEnumerator WaitForAttack(Player player)
    {
        var waitForOneSecond = new WaitForSeconds(_delay);

        while (_canAttack)
        {
            Attack(player);
            yield return waitForOneSecond;
        }
    }
}