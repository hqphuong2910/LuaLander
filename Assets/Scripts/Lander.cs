using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts {
    public class Lander : MonoBehaviour {

        public event EventHandler OnNoForce;
        public event EventHandler OnUpForce;
        public event EventHandler OnLeftForce;
        public event EventHandler OnRightForce;
        private Rigidbody2D landerRb2D;
        private float fuelAmount = 10f;

        private void Awake() {
            landerRb2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            OnNoForce?.Invoke(this, EventArgs.Empty);

            if (fuelAmount <= 0) {
                return;
            }

            if (Keyboard.current.upArrowKey.isPressed ||
                Keyboard.current.leftArrowKey.isPressed ||
                Keyboard.current.rightArrowKey.isPressed) {
                ConsumeFuel();
            }

            if (Keyboard.current.upArrowKey.isPressed) {
                float force = 15f;
                landerRb2D.AddForce(transform.up * force);
                OnUpForce?.Invoke(this, EventArgs.Empty);
            }
            if (Keyboard.current.leftArrowKey.isPressed) {
                float turnSpeed = 2f;
                landerRb2D.AddTorque(turnSpeed);
                OnLeftForce?.Invoke(this, EventArgs.Empty);
            }
            if (Keyboard.current.rightArrowKey.isPressed) {
                float turnSpeed = -2f;
                landerRb2D.AddTorque(turnSpeed);
                OnRightForce?.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision2D) {
            if (!collision2D.gameObject.TryGetComponent(out LandingPad landingPad)) {
                Debug.Log("Crashed on terrain.");
                return;
            }

            float softLandingVelocityMagnitude = 4f;
            float relativeVelocityMagnitude = collision2D.relativeVelocity.magnitude;
            if (relativeVelocityMagnitude > softLandingVelocityMagnitude) {
                Debug.Log("Landed too hard.");
                return;
            }

            float dotVector = Vector2.Dot(Vector2.up, transform.up);
            float minDotVector = 0.85f;
            if (dotVector <= minDotVector) {
                Debug.Log("Landed on a too steep angle.");
                return;
            }

            Debug.Log("Successful landing");

            int landingSpeedScoreAmount = 100;
            float landingSpeedScore = (softLandingVelocityMagnitude - relativeVelocityMagnitude) * landingSpeedScoreAmount;

            int landingAngleMaxScoreAmount = 100;
            float dotVectorScoreMultiplier = 10f;
            float landingAngleScore = landingAngleMaxScoreAmount - Mathf.Abs(dotVector - 1f) * dotVectorScoreMultiplier * landingAngleMaxScoreAmount;

            Debug.Log("Landing speed score: " + landingSpeedScore);
            Debug.Log("Landing angle score: " + landingAngleScore);

            float totalScore = Mathf.RoundToInt(landingSpeedScore + landingAngleScore) * landingPad.GetScoreMultiplier();
            Debug.Log("Total score: " + totalScore);
        }

        private void OnTriggerEnter2D(Collider2D collider2D) {
            if (collider2D.TryGetComponent(out FuelPickup fuelPickup)) {
                float fuelAddAmount = 10f;
                fuelAmount += fuelAddAmount;
                fuelPickup.DestroySelf();
                Debug.Log("Remaining fuel: " + fuelAmount);
            }
        }

        private void ConsumeFuel() {
            float fuelConsumeAmount = 1f;
            fuelAmount -= fuelConsumeAmount * Time.fixedDeltaTime;
            if (fuelAmount < 0) {
                fuelAmount = 0;
                Debug.Log("Out of fuel.");
                return;
            }
            Debug.Log("Remaining fuel: " + fuelAmount);
        }
    }
}
