using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Bullet _bullet;

    protected bool _canShoot;

    public Bullet Bullet => _bullet;

    public abstract void Shoot(Transform shootPoint);
}