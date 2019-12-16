using UnityEngine;
using Sirenix.OdinInspector;

public class Wheel : SerializedMonoBehaviour
{
    WheelCollider wheel;
    [ShowInInspector]
    public float BrakeTorque{ get { if (wheel) return wheel.brakeTorque; else return -1f; } set {wheel.brakeTorque = value; } }
    void Start()
    {
        wheel = GetComponent<WheelCollider>();
    }

}
