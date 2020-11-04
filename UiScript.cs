using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
public class UiScript : MonoBehaviour
{
    [Header("Slider")]
    public GameObject loadingSlider;
    public Text textOfSliderLoading;
    public Slider mainSlider;
    AsyncOperation loadingScrTime;
    float hundredPercante;
    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("tutCompleted", 0) == 0)
        {
            loadingScrTime = SceneManager.LoadSceneAsync(1);
        }
        if (PlayerPrefs.GetInt("tutCompleted", 0) == 1)
        {
            loadingScrTime = SceneManager.LoadSceneAsync(2);
        }
        loadingSlider.SetActive(true);

        while (hundredPercante != 100)
        {
            hundredPercante = loadingScrTime.progress * 100 * 10 / 9;
            mainSlider.value = hundredPercante;
            textOfSliderLoading.text = hundredPercante.ToString() + "%";
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpernUrl()
    {
        Application.OpenURL("https://i-am-game-developer.itch.io");
    }
    public void YTChannel()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCKzVEKaWx58k1FG3DaMbSQQ");
    }
}
