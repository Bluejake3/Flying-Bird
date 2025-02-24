using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float pipeSpeed;
    Rigidbody2D pipeBody;
    GameManager gameManager;
    

    private void Awake() {
        pipeBody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetGameStarted() && !gameManager.GetGameFinished()){
            Move();
            if (pipeBody.position.x <= -35){
                Destroy(gameObject);
            } 
        }
          
    }
    void Move(){
      Vector2 newPosition = new Vector2();
      newPosition.x = transform.position.x - pipeSpeed  * Time.deltaTime;
      newPosition.y = transform.position.y;
      transform.position = newPosition;
    }
}
