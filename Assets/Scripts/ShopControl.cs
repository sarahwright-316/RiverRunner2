using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    public void SelectGameLevel()
    {
        LevelSelector.selectedLevel = "Game2";
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectCityLevel()
    {
        LevelSelector.selectedLevel = "City";
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectMountainsLevel()
    {
        LevelSelector.selectedLevel = "Mountains";
        SceneManager.LoadScene("MainMenu");
    }
}
