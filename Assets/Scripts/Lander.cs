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

    private void OnCollisionEnter2D(Collision2D collision2D) {
        var smoothLandingVelocityMagnitude = 4f;
        if (collision2D.relativeVelocity.magnitude > smoothLandingVelocityMagnitude) {
            Debug.Log("Landed too hard.");
            return;
        }

        var dotVector = Vector2.Dot(Vector2.up, transform.up);
        var minDotVector = 0.85f;
        if (dotVector <= minDotVector) {
            Debug.Log("Landed on a too steep angle.");
            return;
        }

        Debug.Log("Successful landing");
    }
}
