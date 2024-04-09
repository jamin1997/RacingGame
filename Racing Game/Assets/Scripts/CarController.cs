using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;
    private bool isBreaking;
    private float flipStrength = 2f;
    float time;
    private float XRot;
    private float YRot;

    [SerializeField] Rigidbody rb;
    [SerializeField] public static float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    // Start is called before the first frame update

    private void Start()
    {
        motorForce = 1000;
        time = Time.deltaTime * 10;
        this.enabled = false;
        StartCoroutine(WaitThreeSeconds());
    }

    IEnumerator WaitThreeSeconds()
    {
        yield return new WaitForSeconds(3);
        this.enabled = true;
    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        if (isBreaking)
        {
            breakForce = 9000;
            ApplyBreaking();
        }
    }

    private void RemoveBreaking()
    {
        frontLeftWheelCollider.brakeTorque = 0;
        frontRightWheelCollider.brakeTorque = 0;
        backLeftWheelCollider.brakeTorque = 0;
        backRightWheelCollider.brakeTorque = 0;
    }

    private void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = breakForce;
        frontRightWheelCollider.brakeTorque = breakForce;
        backLeftWheelCollider.brakeTorque = breakForce;
        backRightWheelCollider.brakeTorque = breakForce;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steeringAngle = maxSteeringAngle * horizontalInput;
        frontRightWheelCollider.steerAngle = steeringAngle;
        frontLeftWheelCollider.steerAngle = steeringAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void Update()
    {
        XRot = rb.transform.rotation.eulerAngles.x;
        YRot = rb.transform.rotation.eulerAngles.y;

        if(Input.GetKey(KeyCode.Space))
        {
            ApplyBreaking();
        }
        RemoveBreaking();
        if (Input.GetKey(KeyCode.R))
        {
            rb.transform.rotation = Quaternion.Euler(XRot, YRot, 0);
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
        float flipStrength = 1f;
        if (time > 3)
        {
            this.enabled = true;
        }
        if (Mathf.Abs(transform.localRotation.eulerAngles.z) > 90f)
        {
            rb.AddRelativeTorque(0f, 0f, flipStrength, ForceMode.Acceleration);
        }
    }

}
