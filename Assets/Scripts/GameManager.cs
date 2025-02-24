using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameStarted = false;
    bool gameFinished = false;
    int score;
    UIManager uIManager;
    [SerializeField] private float finishDelay;

    private void Awake() {
        uIManager = FindObjectOfType<UIManager>();
    }

    void Start(){
        score = 0;
    }

    public bool GetGameStarted(){
        return gameStarted;
    }

    public bool GetGameFinished(){
        return gameFinished;
    }
    public int GetScore(){
        return score;
    }

    public void AddScore(){
        score++;
        uIManager.SetScore(score);
    }

    public void StartGame(){
        gameStarted = true;
    }
    public void EndGame(){
        gameFinished = true;
        Invoke("FinishGameInvoker", finishDelay);
    }

    void FinishGameInvoker(){
        uIManager.FinishGame();
    }
}
