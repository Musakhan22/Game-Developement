using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;


    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

     [SerializeField] private Transform frontLeftWheelTransform;
     [SerializeField] private Transform frontRightWheelTransform;
     [SerializeField] private Transform rearLeftWheelTransform;
     [SerializeField] private Transform rearRightWheelTransform;
    

   private void FixedUpdate() {
       GetInput();
       HandleMotor();
       HandleSteering();
       UpdateWheels();
   }

   private void GetInput()
       {
           horizontalInput = Input.GetAxis(HORIZONTAL);
           verticalInput = Input.GetAxis(VERTICAL);
           isBreaking =    Input.GetKey(KeyCode.Space);


       }

   private void HandleMotor() 
       {
           frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
           frontRightWheelCollider.motorTorque = verticalInput * motorForce;
           currentbreakForce = isBreaking ? breakForce : 0f;
           if (isBreaking)
           {
               ApplyBreaking();
           }
       }

  private void ApplyBreaking()
  {
       frontRightWheelCollider.brakeTorque = currentbreakForce;
       frontLeftWheelCollider.brakeTorque = currentbreakForce;
       rearLeftWheelCollider.brakeTorque = currentbreakForce;
       rearRightWheelCollider.brakeTorque = currentbreakForce;
  }

  private void HandleSteering()
  {
      currentSteerAngle = maxSteerAngle * horizontalInput;
      frontLeftWheelCollider.steerAngle = currentSteerAngle;
      frontRightWheelCollider.steerAngle = currentSteerAngle;
  }

  private void UpdateWheels()
  {
    UpdateSingleWheels(frontLeftWheelCollider,   frontLeftWheelTransform);
    UpdateSingleWheels(frontRightWheelCollider,  frontRightWheelTransform);
    UpdateSingleWheels(rearRightWheelCollider,    rearRightWheelTransform);
    UpdateSingleWheels(rearLeftWheelCollider,     rearLeftWheelTransform);   
  }
   
   private void UpdateSingleWheels(WheelCollider WheelCollider, Transform WheelTransform)
   {    
       Vector3 pos;
       Quaternion rot;
       WheelCollider.GetWorldPose(out pos, out rot);
       WheelTransform.rotation = rot;
       WheelTransform.position = pos;
   }


   
   
}
