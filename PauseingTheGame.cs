using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class PauseingTheGame : MonoBehaviour
{
    #region variables
    public static bool paused = false;
    public GameObject pausePanel;
    public GameObject buttonsCanvas;
    [Space]
    [Header("Loading Slider")]
    public GameObject loadingSlider;
    public Text textOfSliderLoading;
    public Slider mainSlider;
    AsyncOperation loadingScrTime;
    float hundredPercante;
    #endregion
    public void PauseTheGame()
    {
        paused = true;
        pausePanel.SetActive(true);
        buttonsCanvas.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ResumeTheGame()
    {
        paused = false;
        pausePanel.SetActive(false);
        buttonsCanvas.SetActive(true);
        Time.timeScale = 1f;
    }
    public void RestartTheGame()
    {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        loadingScrTime = SceneManager.LoadSceneAsync(0);
        loadingSlider.SetActive(true);
        while (hundredPercante != 100)
        {
            hundredPercante = loadingScrTime.progress * 100 * 10 / 9;
            mainSlider.value = hundredPercante;
            textOfSliderLoading.text = hundredPercante.ToString() + "%";
            if(hundredPercante > 89)
            {
                paused = false;
            }
        }
    }


}
