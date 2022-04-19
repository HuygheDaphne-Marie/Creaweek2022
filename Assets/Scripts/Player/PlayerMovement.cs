using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 10;
    private Vector2 _movementInput = Vector2.zero;
    public Vector2 MovementInput
    {
        get { return _movementInput; }
    }
    public float GravityValue = -9.81f;
    private bool GroundedPlayer = false;
    private Vector3 Velocity = Vector3.zero;

    private CharacterController _controller = null;

    public void OnMovement(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void Update()
    {
        // Update groundedPlayer bool
        GroundedPlayer = _controller.isGrounded;

        // Stop gravity pull if grounded
        if (GroundedPlayer && Velocity.y < 0)
        {
            Velocity.y = 0f;
        }

        // Calculate the movement vector from the player input, taking into account the map tilt (and compensating for the ortographic FOV skew)
        Vector3 movementDir = new Vector3(_movementInput.x, 0, _movementInput.y);
        Vector3 movement = movementDir * MovementSpeed;

        // Update the forward vector
        Velocity += movement * Time.deltaTime;
        if (movementDir != Vector3.zero)
        {
            gameObject.transform.forward = movementDir.normalized;
        }

        // Add the gravity effect to the velocity
        Velocity.y += GravityValue * Time.deltaTime;

        // And actually move, according to the calculated velocity
        _controller.Move(Velocity * Time.deltaTime);
    }
}
