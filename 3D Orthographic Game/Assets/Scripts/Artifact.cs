using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public int minScore, maxScore;
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        transform.Rotate(180f*Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) ;
        {
            gameManager.AddScore(Random.Range(minScore, maxScore));
            Destroy(gameObject);
        }
    }

}
