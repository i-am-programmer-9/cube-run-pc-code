using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	#region variables
	int unlockedLevel;
	
	public Button[] buttons;
	[Space]
	[Header("Slider")]
    public GameObject loadingSlider;
    public Text textOfSliderLoading;
    public Slider mainSlider;
    AsyncOperation loadingScrTime;
    float hundredPercante;
	#endregion
	void Start()
	{
		unlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);
		for(int i = 0; i < buttons.Length; i++)
		{
			buttons[i].interactable = false;
		}
		for(int i = 0; i < unlockedLevel; i++)
		{
			buttons[i].interactable = true;
		}
	}
	public void Level1()
	{
		loadingScrTime = SceneManager.LoadSceneAsync(3);
		LoadingThing();
	}
	public void Level2()
	{
		loadingScrTime = SceneManager.LoadSceneAsync(6);
		LoadingThing();
	}
	public void Level3()
	{
		loadingScrTime = SceneManager.LoadSceneAsync(9);
		LoadingThing();
	}
	public void Level4()
	{
		loadingScrTime = SceneManager.LoadSceneAsync(12);
		LoadingThing();
	}
	public void Level5()
	{
		loadingScrTime = SceneManager.LoadSceneAsync(15);
		LoadingThing();
	}
	public void Tutorial()
	{
		loadingScrTime = SceneManager.LoadSceneAsync(1);
		LoadingThing();
	}
	private void LoadingThing()
	{
        loadingSlider.SetActive(true);

        while(hundredPercante != 100)
        {
            hundredPercante = loadingScrTime.progress * 100 * 10 / 9;
            mainSlider.value = hundredPercante;
            textOfSliderLoading.text = hundredPercante.ToString() + "%";
        }
	}

}
