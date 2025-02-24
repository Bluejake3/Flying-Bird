using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    bool gameStarted = false;
    bool gameFinished = false;
    Vector2 movement;

    [Header("Gameplay factors")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;

    Rigidbody2D playerBody;
    Animator animation;

    [Header("Audio")]
    [SerializeField] private AudioClip pointScoreAudio;
    [SerializeField] private AudioClip flapAudio;
    [SerializeField] private AudioClip HitAudio;
    [SerializeField] private float maxPitch, minPitch;
    AudioSource audioSource;
    UIManager uIManager;


    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        playerBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        uIManager = FindObjectOfType<UIManager>();
        animation = GetComponent<Animator>();
    }
    
    private void Start() {
        playerBody.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        AudioSource.PlayClipAtPoint(pointScoreAudio, Camera.main.transform.position);
        gameManager.AddScore();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        gameManager.EndGame();
        AudioSource.PlayClipAtPoint(HitAudio, Camera.main.transform.position);
        animation.speed = 0;
    }


    void OnFire(InputValue value){
        if(!gameManager.GetGameStarted()){
            playerBody.gravityScale = gravity;
            uIManager.SetScore(0);
            gameManager.StartGame();
        }
        if(!gameManager.GetGameFinished()){
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.PlayOneShot(flapAudio);
            playerBody.velocity = new Vector2(0, jumpHeight);

        }
    }
}
