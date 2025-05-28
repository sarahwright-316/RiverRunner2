using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] GameObject fadeOut;

    public void StartGame()
    {
        StartCoroutine(StartButton(LevelSelector.selectedLevel));
    }

    public void GoToShop()
    {
        StartCoroutine(StartButton("ShopScene")); // Make sure "ShopScene" is in Build Settings
    }

    IEnumerator StartButton(string sceneName)
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
