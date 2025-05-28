using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class ShopControl : MonoBehaviour
{
    public TMP_Text feedbackText;
    public TMP_Text coinDisplay;

    private int cityCost = 3;
    private int mountainsCost = 50;

    // Removed PlayerPrefs.DeleteAll() so coins won't reset every start

    void Start()
    {
        coinDisplay.text = "Coins: " + MasterInfo.coinCount;
    }

    public void SelectGameLevel()
    {
        LevelSelector.selectedLevel = "Game2";
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectCityLevel()
    {
        HandleLevelSelection("City", cityCost);
    }

    public void SelectMountainsLevel()
    {
        HandleLevelSelection("Mountains", mountainsCost);
    }

    private void HandleLevelSelection(string levelName, int cost)
    {
        if (LevelSelector.IsLevelUnlocked(levelName))
        {
            LevelSelector.selectedLevel = levelName;
            SceneManager.LoadScene("MainMenu");
        }
        else if (MasterInfo.coinCount >= cost)
        {
            MasterInfo.coinCount -= cost;
            LevelSelector.UnlockLevel(levelName);
            feedbackText.text = $"{levelName} Level purchased!";
            coinDisplay.text = "Coins: " + MasterInfo.coinCount;
            LevelSelector.selectedLevel = levelName;

            StartCoroutine(DelayedSceneLoad("MainMenu", 2f));
        }
        else
        {
            feedbackText.text = $"Not enough coins to unlock {levelName}! Need {cost}.";
        }
    }

    private IEnumerator DelayedSceneLoad(string sceneName, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(sceneName);
    }
}
