using UnityEngine;

public class GameDebugger : MonoBehaviour
{
    // This adds a button in the Inspector window
    [ContextMenu("CLEAR ALL SAVED DATA")]
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("<color=red>ALL PLAYER DATA WIPED!</color> Please restart the game to see changes.");
    }
    
    // Quick tip: You can also map this to a key for fast testing
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            ClearPlayerPrefs();
        }
    }
}