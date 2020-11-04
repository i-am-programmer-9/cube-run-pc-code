using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelsLosingAndWinning : MonoBehaviour
{
    #region variables
    [Header("Loading Slider Variables")]
    public GameObject loadingObject;
    public Slider mainSlider;
    public Text textInsideSlider;
    AsyncOperation loadingScrTime;
    float percanteCompleted;
    #endregion
    private void Update()
    {
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
		{
			NextLevel();
		}
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home))
		{
			ManMenu();
		}
    }
    public void Replay()
    {
        loadingScrTime = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        fullLoading();
    }
    public void WinningReplay()
    {
        loadingScrTime = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 2);
        fullLoading();
    }
    public void ManMenu()
    {
        loadingScrTime = SceneManager.LoadSceneAsync(0);
        fullLoading();
    }
    public void NextLevel()
    {
        loadingScrTime = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        fullLoading();
    }
    private void fullLoading()
    {
        loadingObject.SetActive(true);

        while (percanteCompleted != 100)
        {
            percanteCompleted = loadingScrTime.progress * 100 * 10 / 9;
            mainSlider.value = percanteCompleted;
            textInsideSlider.text = percanteCompleted.ToString() + "%";
        }
    }
}
