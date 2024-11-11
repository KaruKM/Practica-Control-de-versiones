using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehaviour : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] int mainMenuScene;

    public delegate void OnPauseDelegate(bool isPaused);
    event OnPauseDelegate OnPauseEvent;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        this.gameObject.SetActive(false);
        if(OnPauseEvent != null)
        {
            OnPauseEvent(true);
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        this.gameObject.SetActive(true);
        if (OnPauseEvent != null)
        {
            OnPauseEvent(false);
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void RegisterFuncitonToCall(OnPauseDelegate f)
    {
        OnPauseEvent += f;
    }

    public void UnregisterFuncitonToCall(OnPauseDelegate f)
    {
        OnPauseEvent -= f;
    }

}
