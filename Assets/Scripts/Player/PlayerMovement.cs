using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    private const string IsMove = "IsMove";

    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private PlayerControls _playerControls;

    private void Awake()
    {
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
        _spriteRenderer.flipX = direction.x > 0 ? false : true;
    }

    private void AnimateMove(Vector2 direction)
    {
        _animator.SetBool(IsMove, direction.x != 0 || direction.y != 0);
    }
}