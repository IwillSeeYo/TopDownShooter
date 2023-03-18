using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private AudioClip _shootFX;

    private PlayerControls _playerControls;
    private Player _player;
    private AudioSource _audioSource;

    private void Awake()
    {
        _playerControls = new PlayerControls();

        _playerControls.Enable();
        _playerControls.Actions.Shoot.performed += ctx => OnShoot();
    }
    private void Start()
    {
        _player = GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnShoot()
    {
        if (Time.timeScale > 0)
            _player.CurrentWeapon.Shoot(_shootPoint);

        _audioSource.PlayOneShot(_shootFX);
    }
}