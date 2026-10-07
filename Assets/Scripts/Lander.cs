using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour {
    private Rigidbody2D landerRb2D;

    private void Awake() {
        landerRb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
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
        if (!collision2D.gameObject.TryGetComponent(out LandingPad landingPad)) {
            Debug.Log("Crashed on terrain.");
            return;
        }

        var softLandingVelocityMagnitude = 4f;
        var relativeVelocityMagnitude = collision2D.relativeVelocity.magnitude;
        if (relativeVelocityMagnitude > softLandingVelocityMagnitude) {
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

        var landingSpeedScoreAmount = 100;
        var landingSpeedScore = (softLandingVelocityMagnitude - relativeVelocityMagnitude) * landingSpeedScoreAmount;

        var landingAngleMaxScoreAmount = 100;
        var dotVectorScoreMultiplier = 10f;
        var landingAngleScore = landingAngleMaxScoreAmount - Mathf.Abs(dotVector - 1f) * dotVectorScoreMultiplier * landingAngleMaxScoreAmount;

        Debug.Log("Landing speed score: " + landingSpeedScore);
        Debug.Log("Landing angle score: " + landingAngleScore);

        var totalScore = Mathf.RoundToInt(landingSpeedScore + landingAngleScore) * landingPad.GetScoreMultiplier();
        Debug.Log("Total score: " + totalScore);
    }
}
