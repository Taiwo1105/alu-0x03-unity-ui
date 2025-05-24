using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Controls player movement on the XZ plane using physics and tracks score/health.
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;      // Editable movement speed
    public int health = 5;          // Player health set to 5 in Inspector
    public Text scoreText;          // UI Text object for displaying score

    private Rigidbody rb;
    private int score = 0;          // Tracks collected pickups

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetScoreText(); // Initialize score display
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false); // Or use Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }

    private void SetScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}

