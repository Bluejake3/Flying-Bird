using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpirteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    GameManager gameManager;

    Vector2 offset;
    Material material;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.GetGameFinished()){
            offset += moveSpeed * Time.deltaTime;
            material.mainTextureOffset = offset; 
        }     
    }
}
