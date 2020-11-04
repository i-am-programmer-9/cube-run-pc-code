using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TutLosingAndWinning : MonoBehaviour
{
    #region Variables
    // Canvas
    [Header("All Canvas")]
    public GameObject winningCanvas;
    public GameObject losingCanvas;
    public GameObject level;
    [Space]
    [Header("Loading Slider Variables")]
    public GameObject loadingSliderObj;
    public Slider mainSlider;
    public Text valueOfLoading;
    AsyncOperation loadingScrTime;
    float percanteCompleted;
    #endregion
    public void DieThePlayer()
    {
        losingCanvas.SetActive(true);
        level.SetActive(false);
    }
    public void Replay()
    {
        loadingScrTime = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        fullLoading();
    }
    public void win()
    {
        winningCanvas.SetActive(true);
        level.SetActive(false);
    }
    public void MainMenu()
    {
        loadingScrTime = SceneManager.LoadSceneAsync(0);
        fullLoading();
    }
    public void SelectLevel()
    {
        PlayerPrefs.SetInt("tutCompleted", 1);
        PlayerPrefs.Save();
        loadingScrTime = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        fullLoading();
    }
    
	private void fullLoading()
	{
        loadingSliderObj.SetActive(true);

        while(percanteCompleted != 100)
        {
            percanteCompleted = loadingScrTime.progress * 100 * 10 / 9;
            mainSlider.value = percanteCompleted;
            valueOfLoading.text = percanteCompleted.ToString() + "%";
        }
    }
}
