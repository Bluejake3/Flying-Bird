using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float timeBetweenPipes;
    [SerializeField] private float bottomLimit, topLimit;
    GameManager gameManager;
    [SerializeField] private GameObject pipeObstacle;
    Vector2 newPosition;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        StartCoroutine(SpawnPipes());
        Debug.Log("coroutine started");
    }

    IEnumerator SpawnPipes(){
        Debug.Log("coroutine running");
        while(true){
            if(!gameManager.GetGameFinished() && gameManager.GetGameStarted()){
                newPosition.y = Random.Range(bottomLimit, topLimit);
                newPosition.x = transform.position.x;
                transform.position = newPosition; 
                Instantiate(pipeObstacle, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(timeBetweenPipes);
        }
        
    }
}
