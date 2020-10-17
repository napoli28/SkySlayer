using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public Vector3 speed;
    public Engine leftEngine;
    public Engine rightEngine;
    public Weapon leftWeapon;
    public Weapon rightWeapon;
    public Transform wing;
    public Transform aileronLeft;
    public Transform aileronRight;
    public Transform horizontalStabilizer;
    public Transform elevator;
    public Transform verticalStabilizer;
    public Transform rudder;
    public float turnSpeed;
    public float riseFactor;
    public float power;
    public float fuelTank;
    public Vector3 velocity;
    public Vector3 localVelocity;

    Vector2 axis;

    private Rigidbody rigidBody;

    float deltaTime;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        leftEngine.TurnOn();
        rightEngine.TurnOn();
        leftWeapon.airplane = this;
        rightWeapon.airplane = this;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime = Time.deltaTime;
        UpdateVelocity();
        UpdataPower();
        EnginePowerControl();
        DirectionControl();
        AirForce();
        FuelConsume();
        FireWeapon();
        Animation();
    }

    void UpdateVelocity()
    {
        velocity = rigidBody.velocity;
        localVelocity = transform.worldToLocalMatrix.MultiplyVector(velocity);
    }
    void UpdataPower()
    {
        power = leftEngine.currentPower + rightEngine.currentPower;
    }
    void DirectionControl()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            axis += new Vector2(Input.GetAxis("Mouse X") * 0.03f, Input.GetAxis("Mouse Y") * 0.08f);
        }
        else
        {
            axis = Vector2.Lerp(axis, Vector2.zero, 10 * deltaTime);
        }
        axis = new Vector2(Mathf.Clamp(axis.x, -1, 1), Mathf.Clamp(axis.y, -1, 1));

    }

    void FireWeapon()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            leftWeapon.Fire();
            rightWeapon.Fire();
        }
    }

    void AirForce()
    {
        Forward();
        //Rise();
        //Aileron();
        //Elevator();
        //VerticalStabilizer();
        void Forward()
        {
            rigidBody.AddForce(power * transform.forward * deltaTime * 10);
        }
        void Rise()
        {
            rigidBody.AddForceAtPosition(transform.up * localVelocity.z * riseFactor * deltaTime, wing.position);
        }
        void Aileron()
        {
            var force = axis.x * 100 * localVelocity.z * deltaTime;
            rigidBody.AddForceAtPosition(force * aileronLeft.up, aileronLeft.position);
            rigidBody.AddForceAtPosition(-force * aileronRight.up, aileronRight.position);
        }
        void Elevator()
        {
            rigidBody.AddForceAtPosition(axis.y * 200 * transform.up * localVelocity.z * deltaTime, elevator.position);
        }
        void VerticalStabilizer()
        {
            rigidBody.AddForceAtPosition(-localVelocity.x * transform.right * deltaTime * 200f, verticalStabilizer.position);
        }
    }

    void FuelConsume()
    {
        fuelTank -= power * 0.00000001f * deltaTime;
    }
    void EnginePowerControl()
    {
        var change = Input.GetAxis("Mouse ScrollWheel") * 0.5f;
        leftEngine.PowerControl = change;
        rightEngine.PowerControl = change;
    }

    void Animation()
    {
        aileronLeft.localEulerAngles = new Vector3(-axis.x * 30, 0, 0);
        aileronRight.localEulerAngles = new Vector3(axis.x * 30, 0, 0);
        elevator.localEulerAngles = new Vector3(-axis.y * 30, 0, 0);
    }
}
