using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    GameManager gameManager;
    [Header("Text Editors")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    [Header("Game Object Containers")]
    [SerializeField] private GameObject scoreTextContainer;
    [SerializeField] private GameObject finalScoreContainer;

    [Header("Animations")]
    Animator finalScoreAnimations;
    Animator scoreTextAnimations;
    
    private void Awake() {
        finalScoreAnimations = finalScoreContainer.GetComponent<Animator>();
        scoreTextAnimations = scoreTextContainer.GetComponent<Animator>();
        finalScoreContainer.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start() {
        scoreText.text = "Click to Start";
    }

    public void SetScore(int score){
        scoreText.text = score.ToString();
    }

    public void FinishGame(){
        finalScoreContainer.SetActive(true);
        finalScoreText.text = "Game Over \n" + "Score:" + gameManager.GetScore().ToString();

        scoreTextAnimations.SetTrigger("gameFinished");
        finalScoreAnimations.SetTrigger("gameFinished");
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
    }

}
