
using UnityEngine;

// Rotates the coin on the x-axis
public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Rotate 45 degrees per second on the x-axis
        transform.Rotate(45 * Time.deltaTime, 0, 0);
    }
}
