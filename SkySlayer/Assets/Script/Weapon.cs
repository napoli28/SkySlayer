using UnityEngine;
using Sirenix.OdinInspector;
public class Weapon : SerializedMonoBehaviour
{
    public Bullet bullet;
    [ShowInInspector]

    private float fireRate;
    public float FireRate
    {
        get { return fireRate; }
        set
        {
            if (value > 0.01)
            {
                fireRate = value; fireInterval = 1 / fireRate;
            }
        }
    }
    public Airplane airplane;
    float fireInterval;
    public void Start()
    {
        fireInterval = 1 / fireRate;
        cd = 0;
    }
    public void Update()
    {
        if (cd < fireInterval)
        {
            cd += Time.deltaTime;
        }
    }

    float cd;

    public void Fire()
    {
        if (cd>= fireInterval)
        {
            var _bullet = Instantiate(bullet, transform.position, transform.rotation);
            _bullet.inertia = airplane.velocity;
            cd = 0;
        }
    }
}