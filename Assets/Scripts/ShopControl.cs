using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI; // Add this for Image

public class ShopControl : MonoBehaviour
{
    public TMP_Text feedbackText;
    public TMP_Text coinDisplay;

    public GameObject cityLockIcon;
    public GameObject mountainsLockIcon;

    private int cityCost = 250;
    private int mountainsCost = 500;

    void Start()
    {
        coinDisplay.text = "Coins: " + MasterInfo.coinCount;

        // 👇 Update lock icon visibility
        cityLockIcon.SetActive(!LevelSelector.IsLevelUnlocked("City"));
        mountainsLockIcon.SetActive(!LevelSelector.IsLevelUnlocked("Mountains"));
    }

    public void SelectGameLevel()
    {
        LevelSelector.selectedLevel = "Game2";
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectCityLevel()
    {
        HandleLevelSelection("City", cityCost, cityLockIcon);
    }

    public void SelectMountainsLevel()
    {
        HandleLevelSelection("Mountains", mountainsCost, mountainsLockIcon);
    }

    public void RefreshLockIcons()
    {
        cityLockIcon.SetActive(!LevelSelector.IsLevelUnlocked("City"));
        mountainsLockIcon.SetActive(!LevelSelector.IsLevelUnlocked("Mountains"));
    }

    private void HandleLevelSelection(string levelName, int cost, GameObject lockIcon)
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
            feedbackText.text = $"              {levelName} Level purchased!";
            coinDisplay.text = "Coins: " + MasterInfo.coinCount;
            LevelSelector.selectedLevel = levelName;

            if (lockIcon != null)
                lockIcon.SetActive(false); // 👈 Hide lock after purchase

            StartCoroutine(DelayedSceneLoad("MainMenu", 2f));
        }
        else
        {
            feedbackText.text = $"Not enough coins to unlock {levelName}! Need {cost}.";
        }
    }

    private System.Collections.IEnumerator DelayedSceneLoad(string sceneName, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(sceneName);
    }
}
