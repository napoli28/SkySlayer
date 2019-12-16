using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Transform follower;
    public float distance;
    public Vector3 angle;
    public Vector3 offset;
    public float lerpT;

    private void Start()
    {
        InitializeFollower();   
    }
    void LateUpdate()
    {
        TargetLerp();
        transform.position = SphereSurfacePosition(offset, distance, angle);
        transform.LookAt(follower.position + offset, follower.up);
    }
    void InitializeFollower()
    {
        follower.position = target.position;
        follower.rotation = target.rotation;
    }

    void TargetLerp()
    {
        follower.position = Vector3.Lerp(follower.position, target.position, 1);
        follower.rotation = Quaternion.Lerp(follower.rotation, target.rotation, lerpT);
    }
    Vector3 SphereSurfacePosition(Vector3 center, float r, Vector3 angle)
    {
        Vector3 result = new Vector3();
        angle *= Mathf.Deg2Rad;
        result.x = r * Mathf.Cos(angle.y) * Mathf.Sin(angle.x);
        result.z = r * Mathf.Sin(angle.y) * Mathf.Sin(angle.x);
        result.y = r * Mathf.Cos(angle.x);
        result += center;
        result = follower.localToWorldMatrix.MultiplyPoint(result);
        return result;
    }
}
