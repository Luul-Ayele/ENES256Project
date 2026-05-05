using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class StartUp : MonoBehaviour
{
    [Header("Scene Settings")]
    public string gameSceneName = "FarmScene"; // The name of your main game scene
    public string menuSceneName = "StartMenu"; // The name of your menu scene

    // 1. START BUTTON: Call this to go to the game
    public void StartGame()
    {
        Debug.Log("Loading Game...");
        SceneManager.LoadScene(gameSceneName);
    }

    // 2. BACK BUTTON: Call this to return to the menu
    public void ReturnToMenu()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene(menuSceneName);
    }

    // 3. EXIT BUTTON: Quits the application
    public void ExitGame()
    {
        Debug.Log("The rabbit has left the garden. (Game Exited)");
        
        // This only works in a built game (.exe), not in the Unity Editor
        Application.Quit(); 
    }
}