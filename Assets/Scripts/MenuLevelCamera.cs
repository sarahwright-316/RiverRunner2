using UnityEngine;

public class MenuLevelCamera : MonoBehaviour
{
    public Transform cameraPos;

    void Start()
    {
        cameraPos.position = new Vector3(0, 3.2f, -20);
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelSelector.selectedLevel == "Game2")
        {
            cameraPos.position = new Vector3(0, 3.2f, -20);
        }
        else if (LevelSelector.selectedLevel == "City")
        {
            cameraPos.position = new Vector3(150.2f, 6, -25.3f);
        }
        else if (LevelSelector.selectedLevel == "Mountains")
        {
            cameraPos.position = new Vector3(338, 2, -29.9f);
        }
    }
}
