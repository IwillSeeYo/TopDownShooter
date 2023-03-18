using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private PlayerControls _playerControls;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerControls = new PlayerControls();

        _playerControls.Enable();
    }

    private void FixedUpdate()
    {
        Move(_playerControls.Actions.Move.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _speed * Time.deltaTime;
        Vector3 move = new Vector3(direction.x, direction.y, 0);

        transform.Translate(move * scaledMoveSpeed);

        Flip(direction);
        AnimateMove(direction);
    }

    private void Flip(Vector2 direction)
    {
        if (direction.x > 0)
            _spriteRenderer.flipX = false;
        else if (direction.x < 0)
            _spriteRenderer.flipX = true;
    }

    private void AnimateMove(Vector2 direction)
    {
        if (direction.x != 0 || direction.y != 0)
            _animator.SetBool("isMove", true);
        else
            _animator.SetBool("isMove", false);
    }
}