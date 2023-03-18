using UnityEngine;

public class Blast : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);

            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}