using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
     
public class SimpleCarController : MonoBehaviour {
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    private Vector3 initialPos;
    private Quaternion initialRot;

    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    
    private void FixedUpdate()
    {
        float forward = inputActions.Car.Forward.ReadValue<float>();
        float backward = inputActions.Car.Backward.ReadValue<float>();
        float throttle = forward - backward;
        float motorTorque = throttle * maxMotorTorque;

        Vector2 steeringInput = inputActions.Car.Steering.ReadValue<Vector2>();
        float steering = steeringInput.x * maxSteeringAngle;

        if(inputActions.Car.Recover.triggered)
        {
            Recover();
        }

        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motorTorque;
                axleInfo.rightWheel.motorTorque = motorTorque;
            }
        }
    }

    public void Recover()
    {
        transform.position = initialPos; 
        transform.rotation = initialRot; 
    }
}