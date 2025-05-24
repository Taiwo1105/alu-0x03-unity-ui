using UnityEngine;
using UnityEngine.SceneManagement; // Required for reloading the scene

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;      // Editable movement speed
    public int health = 5;          // Player health set to 5 in Inspector

    private Rigidbody rb;
    private int score = 0;          // Tracks collected pickups
    private int initialHealth;      // Store initial health for reset
    private int initialScore = 0;   // Store initial score for reset

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialHealth = health;
        score = initialScore;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false); // or use Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
    }
}
