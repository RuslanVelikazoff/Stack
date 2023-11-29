using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Button soundButton;

    [SerializeField]
    private Text highScoreText;

    [SerializeField]
    private Sprite onSprite;
    [SerializeField]
    private Sprite offSprite;

    private void Start()
    {
        SetSprites();
        highScoreText.text = "High score: " + PlayerPrefs.GetFloat("HighScore").ToString();

        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
            });
        }
        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("MusicVolume") == 0)
                {
                    AudioManager.instance.OnMusic();
                }
                else
                {
                    AudioManager.instance.OffMusic();
                }

                SetSprites();
            });
        }
        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("SoundVolume") == 0)
                {
                    AudioManager.instance.OnSound();
                }
                else
                {
                    AudioManager.instance.OffSound();
                }

                SetSprites();
            });
        }
    }

    private void SetSprites()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 0)
        {
            musicButton.GetComponent<Image>().sprite = offSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = onSprite;
        }

        if (PlayerPrefs.GetFloat("SoundVolume") == 0)
        {
            soundButton.GetComponent<Image>().sprite = offSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = onSprite;
        }
    }
}
