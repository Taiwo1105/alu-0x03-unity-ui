using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Call this method from a UI button to start the Maze scene
    public void PlayMaze()
    {
        SceneManager.LoadScene("Maze"); // Replace "Maze" with your actual scene name
    }

    // Call this method from a UI button to quit the game
    public void QuitMaze()
    {
        Debug.Log("Quit Game");

        // Quit the application (works in built game)
        Application.Quit();

        // Stop play mode in Unity Editor (does not quit the editor)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
