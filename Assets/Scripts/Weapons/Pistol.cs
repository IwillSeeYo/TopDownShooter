using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotate = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotate);
        var bullet = Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
    }
}