using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Vector3 MoveForce; //Speed

    public float MoveSpeed = 50; //Speed Multiplier
    public float brakeSpeed = 0.5f;
    public float brakeSlowSpeed = 0.25f;
    public float Friction = 0.99f; //Friction/Drag
    public float MaxSpeed = 20; //Max Speed
    public float SteerAngle = 20; //Angle Multiplier
    public float Traction = 1; //How fast the car returns to moving straight after drifting

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Foward&Back/Vertical Movement
        if (Input.GetAxis("Vertical") < 0)
        {
            MoveForce += transform.forward * MoveSpeed * (Input.GetAxis("Vertical") * brakeSlowSpeed) * Time.deltaTime; //Slows the rate of braking to be more realistic
        } 
        else
        {
            MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime; //Uses input for front and back movement into variable
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveForce *= brakeSpeed; //Slows car down a little, fast to simulate the intial shift in momentum when the brake key is pressed first
        }
        
        transform.position += MoveForce * Time.deltaTime; //Moves car w/ MoveForce variable

        //Steering/Horizontal Movement
        float steeringInput = Input.GetAxis("Horizontal"); //User input for left and right movement
        transform.Rotate(Vector3.up * steeringInput * MoveForce.magnitude * SteerAngle * Time.deltaTime); //Uses the input to turn car

        //Friction
        MoveForce *= Friction;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed); //Sets a max speed

        //Traction
        Debug.DrawRay(transform.position, MoveForce.normalized * 3); //Ray for sideways movement
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue); //Ray for straight
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude; //Uses Vector3.Lerp to realign the sideways movement to straight movement using Traction as a multiplier.

    }
}
