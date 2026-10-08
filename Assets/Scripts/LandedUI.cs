using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LandedUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleTextMesh;
        [SerializeField] private TextMeshProUGUI statsTextMesh;
        [SerializeField] private Button nextButton;

        private void Awake()
        {
            nextButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        }

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
