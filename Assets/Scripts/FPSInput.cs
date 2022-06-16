using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float gravity = -9.8f;
    public float speed = 6.0f;

    private CharacterController _charController;
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float velocityX =  Input.GetAxis("Horizontal") * speed;
        float velocityZ =  Input.GetAxis("Vertical") * speed;

        Vector3 velocity = new Vector3(velocityX, gravity, velocityZ);
        velocity = Vector3.ClampMagnitude(velocity, speed);

        Vector3 movement = velocity * Time.deltaTime;
        // This sets the movement from local to global coordinates i.e. from dr to r + dr
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
