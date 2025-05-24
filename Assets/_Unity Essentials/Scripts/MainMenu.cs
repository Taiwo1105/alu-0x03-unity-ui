using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Call this method from a UI button to start the Maze scene
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze"); // Replace "Maze" with your actual scene name
    }
}
