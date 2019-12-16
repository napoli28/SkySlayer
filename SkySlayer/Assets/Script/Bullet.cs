using UnityEngine;
public class Bullet : MonoBehaviour
{
    public Vector3 inertia;
    public float Speed;
    public float lifeTime;
    float time = 0;
    float deltaTime;
    private void Update()
    {
        deltaTime = Time.deltaTime;
        transform.position += (Speed * transform.forward + inertia) * deltaTime;
        time += deltaTime;
        if (time >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}