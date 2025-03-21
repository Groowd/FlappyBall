using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public AudioClip trapSound;  // Ses dosyasýný buraya sürükle
    private AudioSource audioSource;
    public GameObject infoPanel;
    public TextMeshProUGUI scoreText;
    public float jumpForce;
    public int score;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            infoPanel.SetActive(false);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        scoreText.text = "Score: " + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            
            Time.timeScale = 0f;
            audioSource.PlayOneShot(trapSound);
            StartCoroutine(CallRestartGameAfterDelay(0.7f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
    }

    public void RestartGame()
    {
        // Aktif olan sahneyi yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator CallRestartGameAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // Gerçek zamanlý bekleme
        RestartGame();
    }

}
