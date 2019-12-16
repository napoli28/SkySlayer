using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class AirDrag : MonoBehaviour
{
    public float airDrag;
    Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 velocity = rigidBody.velocity;
        this.velocity = velocity;
        rigidBody.AddForce(DragDebug(-velocity * velocity.magnitude * airDrag * Time.deltaTime));
    }

    public Vector3 velocity;
    public Vector3 dragDebug;
    Vector3 DragDebug(Vector3 drag)
    {
        dragDebug = drag;
        return drag;
    }
}
