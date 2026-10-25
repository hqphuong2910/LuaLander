using Assets._Project.Scripts.Core;
using Assets._Project.Scripts.Managers;
using Assets._Project.Scripts.Player;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI {
    public class LandedUI : CustomMonoBehaviour {
        [SerializeField] private TextMeshProUGUI titleTextMesh;
        [SerializeField] private TextMeshProUGUI statsTextMesh;
        [SerializeField] private Button nextButton;
        [SerializeField] private TextMeshProUGUI nextButtonTextMesh;

        private Action nextButtonClickAction;

        protected override void LoadSelf() {
            base.LoadSelf();

            nextButton.onClick.AddListener(() => nextButtonClickAction());
        }

        protected override void Start() {
            base.Start();

            Hide();
        }

        protected override void SubscribeEvents() {
            base.SubscribeEvents();

            Lander.Instance.OnLanded += Lander_OnLanded;
        }

        protected override void UnsubscribeEvents() {
            base.UnsubscribeEvents();

            Lander.Instance.OnLanded -= Lander_OnLanded;
        }

        private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e) {
            if (e.landingType == Lander.LandingType.Success) {
                titleTextMesh.text = "SUCCCESSFUL LANDING";
                nextButtonTextMesh.text = "CONTINUE";
                nextButtonClickAction = GameManager.Instance.GoToNextLevel;
            } else {
                nextButtonTextMesh.text = "RETRY";
                nextButtonClickAction = GameManager.Instance.RetryLevel;
                titleTextMesh.text = "<color=#ff0000>CRASHED</color>";
            }

            statsTextMesh.text =
                Mathf.Round(e.landingSpeed) + "\n" +
                Mathf.Round(e.dotVector) + "\n" +
                "x" + e.scoreMultiplier + "\n" +
                e.score;

            Show();
        }

        private void Hide() {
            gameObject.SetActive(false);
        }

        private void Show() {
            nextButton.Select();

            gameObject.SetActive(true);
        }
    }
}
