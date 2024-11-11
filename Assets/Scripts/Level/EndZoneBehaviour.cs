using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndZoneBehaviour : MonoBehaviour
{
    [SerializeField]Text endText;
    int sceneToLoad;
    bool ended;
    [SerializeField] string winText;
    [SerializeField] string restartText;

    [SerializeField]float timeToNextLevel;

    private void Start()
    {
        endText.gameObject.SetActive(false);
        endText.text = "";
        ended = false;
    }

    private void Update()
    {
        if (ended)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                {
                    StartCoroutine(ChangeLevel());
                }                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            PlayerScore ps = other.gameObject.GetComponent<PlayerScore>();
            int playerScore = ps.GetScore();
            EndGame(playerScore);
        }
    }
    void EndGame(int score)
    {
        ended = true;
        endText.gameObject.SetActive(true);
        if(score >= 5) 
        {
            sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            endText.text = winText;
            endText.color = Color.green;
        }
        else
        {
            sceneToLoad = SceneManager.GetActiveScene().buildIndex;
            endText.text = restartText;
            endText.color = Color.red;
        }
    }
    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(timeToNextLevel);
        print("Reloading...");
        SceneManager.LoadScene(sceneToLoad);
    }
}