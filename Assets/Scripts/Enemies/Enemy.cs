using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Enemy : MonoBehaviour
{
    private const string ApplyDamageAnimation = "ApplyDamage";

    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _reward;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Player _target;
    private AudioSource _audioSource;

    public Player Target => _target;
    public int Reward => _reward;

    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Flip();
    }

    public void Init(Player target)
    {
        if (target == null)
            return;

        _target = target;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        _animator.Play(ApplyDamageAnimation);
        _audioSource.Play();

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }

    private void Flip()
    {
        if (_target == null)
            return;

        _spriteRenderer.flipX = transform.position.x >_target.transform.position.x ? true: false;
    }
}