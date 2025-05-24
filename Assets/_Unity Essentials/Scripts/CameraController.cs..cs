using UnityEngine;
using UnityEngine.UIElements;

// Makes the camera follow the player with a fixed offset.
public class CameraController : MonoBehaviour
{
    public GameObject player; // Assign in Inspector
private Vector3 offset;   // Stores initial offset between camera and player

void Start()
{
    // Calculate and store the offset at start
    if (player != null)
    {
        offset = transform.position - player.transform.position;
    }
    else
    {
        Debug.LogWarning("Player not assigned in CameraController.cs script.");
    }
}

void LateUpdate()
{
    // Only update if player is assigned
    if (player != null)
    {
        // Maintain the initial offset relative to the player
        transform.position = player.transform.position + offset;
    }
}
}
