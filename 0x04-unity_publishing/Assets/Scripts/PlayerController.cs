using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Public variable to store the rigidbody of the player gameobject.
    public Rigidbody rb;

    // Public variable to store the movement speed of the player gameobject.
    public float speed;

    // Private vairable to store the score of the player gameobject.
    private int score = 0;

    // Public variable to store the health of the player gameobject.
    public int health = 5;

    // Public variable to store the score of the scoteText UI gameobject.
    public Text scoreText;

    // Public variable to store the score of the healthText UI gameobject.
    public Text healthText;

    // Public variable to store the text of WinLoseGB UI gameobject.
    public Text winloseText;

    //
    public GameObject winloseBG;
    
    
    // Update is called when health equals to 0.
    void Update()
    {
        if (health == 0)
        {
            winloseBG.SetActive(true);
            winloseBG.GetComponent<Image>().color = new Color(255, 0, 0);
            winloseText.text = "Game Over!";
            winloseText.GetComponent<Text>().color = new Color(255, 255, 255);
            // Debug.Log("Game Over!");
            StartCoroutine(LoadScene(3));
            // SceneManager.LoadScene("maze");
            health = 0;
            score = 0;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Arrow keys
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, 500 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -500 * Time.deltaTime);
        }


        // WASD keys
        if (Input.GetKey("d"))
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, 500 * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -500 * Time.deltaTime);
        }
    }

    // Increments the value of score when the Player touches an object tagged Pickup.
    // Decrements the value of health when the Player touches an object tagged Trap.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
            // Debug.Log("Score: " + score);
        }
        if (other.gameObject.tag == "Trap")
        {
            health--;
            SetHealthText();
            // Debug.Log("Health: " + health);
        }
        if (other.gameObject.tag == "Goal")
        {
            winloseBG.SetActive(true);
            winloseBG.GetComponent<Image>().color = new Color(0, 255, 0);
            winloseText.text = "You Win!";
            winloseText.GetComponent<Text>().color = new Color(0, 0, 0);
            StartCoroutine(LoadScene(3));
            // Debug.Log("You win!");
        }
    }

    // Updates the ScoreText object value with the Player‘s current score.
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Updates the healthText object value with the player's current health.
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    // Creates a delay where once the Player‘s health is 0 and the Game Over! text is displayed.
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
    }
}
