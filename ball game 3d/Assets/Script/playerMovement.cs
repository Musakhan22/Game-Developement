using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float movement_speed = 1500f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
void FixedUpdate() 
{
    if (Input.GetKey("up"))
    {
        rb.AddForce(0,0, movement_speed * Time.deltaTime);
    }
    if (Input.GetKey("down"))
    {
        rb.AddForce(0,0, -movement_speed * Time.deltaTime);
    }
    if (Input.GetKey("left"))
    {
        rb.AddForce(-movement_speed * Time.deltaTime , 0, 0);
    }
    if (Input.GetKey("right"))
    {
        rb.AddForce(movement_speed * Time.deltaTime,0, 0);
    }
}

}
  

