using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class LanderVisual : MonoBehaviour
    {

        [SerializeField] private ParticleSystem leftThrusterParticleSystem;
        [SerializeField] private ParticleSystem middleThrusterParticleSystem;
        [SerializeField] private ParticleSystem rightThrusterParticleSystem;

        private Lander lander;

        private void Awake()
        {
            lander = GetComponent<Lander>();

            lander.OnNoForce += Lander_OnNoForce;
            lander.OnUpForce += Lander_OnUpForce;
            lander.OnLeftForce += Lander_OnLeftForce;
            lander.OnRightForce += Lander_OnRightForce;
        }

        private void Lander_OnNoForce(object sender, EventArgs e)
        {
            SetEnableThrusterParticleSystem(leftThrusterParticleSystem, false);
            SetEnableThrusterParticleSystem(middleThrusterParticleSystem, false);
            SetEnableThrusterParticleSystem(rightThrusterParticleSystem, false);
        }

        private void Lander_OnUpForce(object sender, EventArgs e)
        {
            SetEnableThrusterParticleSystem(leftThrusterParticleSystem, true);
            SetEnableThrusterParticleSystem(middleThrusterParticleSystem, true);
            SetEnableThrusterParticleSystem(rightThrusterParticleSystem, true);
        }

        private void Lander_OnLeftForce(object sender, EventArgs e)
        {
            SetEnableThrusterParticleSystem(leftThrusterParticleSystem, true);
        }

        private void Lander_OnRightForce(object sender, EventArgs e)
        {
            SetEnableThrusterParticleSystem(rightThrusterParticleSystem, true);
        }

        private void SetEnableThrusterParticleSystem(ParticleSystem particleSystem, bool isEnable)
        {
            ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
            emissionModule.enabled = isEnable;
        }
    }
}
