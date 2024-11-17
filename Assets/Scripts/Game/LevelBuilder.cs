using Game;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        
        SetupGridBounds();
    }

    private void SetupGridBounds()
    {
        var screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Debug.Log("Setup Grid Bounds");
    }

    public void BuildLevel(LevelConfig config)
    {
        Debug.Log($"Building Level {config.Level}");
    }

}
