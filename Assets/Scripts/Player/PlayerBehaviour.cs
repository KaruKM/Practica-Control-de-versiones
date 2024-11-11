using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Text doorText;
    [SerializeField] int lifes = 3;
    int damage;
    bool hasLost;

    [SerializeField]PauseMenuBehaviour pauseMenu;

    private void Start()
    {
        hasLost = false;
        damage = 1;
        pauseMenu.RegisterFuncitonToCall(PauseBall);
        doorText.text = "Life: " + lifes;
        startPosition = Vector3.zero;
    }

    private void Update()
    {
        if (lifes <= 0)
        {
            hasLost = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            LoseLife(damage);
            ResetPosition();
            doorText.text = "Life: " + lifes;
            RestartLevel();
        }
        else if (other.CompareTag("Enemy"))
        {
            doorText.text = "Life: " + lifes;
            RestartLevel();
        }
    }

    public void LoseLife(int damage)
    {
        lifes -= damage;
    }

    public void ResetPosition()
    {
        transform.localPosition = startPosition;
        Rigidbody rb;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void PauseBall(bool isPaused)
    {
        Rigidbody rb;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void RestartLevel()
    {
        if (hasLost) 
        {
            ResetPosition();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            print("Perdiste o7");
        }        
    }
}
