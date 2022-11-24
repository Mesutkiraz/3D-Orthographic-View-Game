using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed=100f;
    public bool isPlayerDead;

    CurrentDirection cr;
    GameManager gameManager;

    private void Update()
    {
        if (!isPlayerDead)
        {
            RaycastDedector();
            if (Input.GetKeyDown("space"))
            {
            ChangeDirection();
            BallStop();
            }
            else
            {
                return;
            }
        }
       
        
        
        
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        isPlayerDead = false;

            rb = GetComponent<Rigidbody>();
            cr = CurrentDirection.right;
        
    }

    private void RaycastDedector()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down, out hit))
        {
            MovePlayer();
        }
        else
        {
            BallStop();
            isPlayerDead = true;
            this.gameObject.SetActive(false) ;
            gameManager.GameEnd();
        }
    }

    private enum CurrentDirection
    {
        right,
        left
    }

    private void ChangeDirection()
    {
        MovePlayer();

        if (cr== CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }
        else if (cr == CurrentDirection.left)
        {
            cr = CurrentDirection.right;
        }
    }

    private void MovePlayer()
    {
        if (cr == CurrentDirection.right)
        {
            rb.AddForce((Vector3.forward).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (true)
        {
            rb.AddForce((Vector3.right).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
    private void BallStop()
    {
        rb.velocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            gameManager.WinLevel();
            this.gameObject.SetActive(false);
            BallStop();
        }
    }
}
