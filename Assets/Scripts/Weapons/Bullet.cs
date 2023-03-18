using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeDestroy;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        _timeDestroy -= Time.time;

        if (_timeDestroy == 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}