using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;           // Material used for Traps
    public Material goalMat;           // Material used for Goal
    public Toggle colorblindMode;      // Toggle for colorblind mode

    // Call this method from a UI button to start the Maze scene
    public void PlayMaze()
    {
        // Check if colorblind mode is enabled
        if (colorblindMode != null && colorblindMode.isOn)
        {
            if (trapMat != null)
            {
                trapMat.color = new Color32(255, 112, 0, 255); // Orange
            }

            if (goalMat != null)
            {
                goalMat.color = Color.blue; // Blue
            }
        }

        SceneManager.LoadScene("Maze"); // Load the Maze scene
    }

    // Call this method from a UI button to quit the game
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}

