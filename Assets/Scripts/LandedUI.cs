using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class LandedUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleTextMesh;
        [SerializeField] private TextMeshProUGUI statsTextMesh;

        private void Start()
        {
            Lander.Instance.OnLanded += Lander_OnLanded;

            Hide();
        }

        private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e)
        {
            if (e.landingType == Lander.LandingType.Success)
            {
                titleTextMesh.text = "SUCCCESSFUL LANDING!";
            }
            else
            {
                titleTextMesh.text = "<color=#ff0000>CRASHED!</color>";
            }

            statsTextMesh.text =
                Mathf.Round(e.landingSpeed) + "\n" +
                Mathf.Round(e.dotVector) + "\n" +
                "x" + e.scoreMultiplier + "\n" +
                e.score;

            Show();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
