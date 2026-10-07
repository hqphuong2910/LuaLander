using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class StatsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI statsTextMesh;
        [SerializeField] private Image fuelBarFillImage;
        [SerializeField] private Image rightArrowImage;
        [SerializeField] private Image leftArrowImage;
        [SerializeField] private Image upArrowImage;
        [SerializeField] private Image downArrowImage;

        private void Update()
        {
            rightArrowImage.enabled = Lander.Instance.GetSpeedX() >= 0;
            leftArrowImage.enabled = Lander.Instance.GetSpeedX() < 0;
            upArrowImage.enabled = Lander.Instance.GetSpeedY() >= 0;
            downArrowImage.enabled = Lander.Instance.GetSpeedY() < 0;

            statsTextMesh.text = GameManager.Instance.GetScore() + "\n" +
                Mathf.Round(GameManager.Instance.GetTime()) + "\n" +
                Mathf.Abs(Mathf.Round(Lander.Instance.GetSpeedX())) + "\n" +
                Mathf.Abs(Mathf.Round(Lander.Instance.GetSpeedY()));
            fuelBarFillImage.fillAmount = Lander.Instance.GetFuelNormalized();
        }
    }
}
