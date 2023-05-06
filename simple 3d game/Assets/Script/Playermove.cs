using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensX = 1f;
    public float mouseSensY = 1f;
    float verticalLookRotation;
    Transform mainCam;
    // Start is called before the first frame update
   void Awake() 
   {
     Cursor.lockState = CursorLockMode.Locked;
     Cursor.visible = false; 
     mainCam = Camera.main.transform;    
   }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensY;
        verticalLookRotation =  Mathf.Clamp(verticalLookRotation, -80, 80);
        mainCam.localEulerAngles = Vector3.left * verticalLookRotation;

        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
         if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }
         if (Input.GetKey("d"))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
         if (Input.GetKey("a"))
        {
            transform.position -= transform.right * Time.deltaTime * moveSpeed;
        }
    }


}
