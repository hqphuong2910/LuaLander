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
            var force = 700f;
            landerRb2D.AddForce(transform.up * (force * Time.deltaTime));
        }
        if (Keyboard.current.leftArrowKey.isPressed) {
            var turnSpeed = 100f;
            landerRb2D.AddTorque(turnSpeed * Time.deltaTime);
        }
        if (Keyboard.current.rightArrowKey.isPressed) {
            var turnSpeed = -100f;
            landerRb2D.AddTorque(turnSpeed * Time.deltaTime);
        }
    }
}
