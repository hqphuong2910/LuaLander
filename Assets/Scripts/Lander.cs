using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{
    private Rigidbody2D landerRb2D;

    private void Awake() {
        landerRb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.isPressed) {
            var force = 15f;
            landerRb2D.AddForce(transform.up * force);
        }
        if (Keyboard.current.leftArrowKey.isPressed) {
            var turnSpeed = 2f;
            landerRb2D.AddTorque(turnSpeed);
        }
        if (Keyboard.current.rightArrowKey.isPressed) {
            var turnSpeed = -2f;
            landerRb2D.AddTorque(turnSpeed);
        }
    }
}
