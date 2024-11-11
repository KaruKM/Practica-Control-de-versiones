using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour
{
    [SerializeField]int rotationLimitZ, rotationLimitX;
    [SerializeField]float rotationSpeedZ, rotationSpeedX;
    [SerializeField]PauseMenuBehaviour pauseMenu;

    bool gamePaused;

    private void Start()
    {
        pauseMenu.RegisterFuncitonToCall(OnPause);
        gamePaused = false;
    }

    void Update()
    {

        if (!gamePaused)
        {
            //Vector3 NewPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            bool aKeyPressed = Input.GetKey(KeyCode.A);
            bool dKeyPressed = Input.GetKey(KeyCode.D);
            bool wKeyPressed = Input.GetKey(KeyCode.W);
            bool sKeyPressed = Input.GetKey(KeyCode.S);

            if (aKeyPressed)
            {
                if (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= (270) || transform.eulerAngles.z <= rotationLimitZ && transform.eulerAngles.z >= -1)
                {
                    Vector3 newRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + rotationSpeedZ);

                    transform.eulerAngles = newRotation;
                }
            }
            else if (dKeyPressed)
            {
                if (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= (360 - rotationLimitZ) || transform.eulerAngles.z <= 90 && transform.eulerAngles.z >= -1)
                {
                    Vector3 newRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - rotationSpeedZ);

                    transform.eulerAngles = newRotation;
                }
            }
            else if (wKeyPressed)
            {
                if (transform.eulerAngles.x <= 360 && transform.eulerAngles.x >= (270) || transform.eulerAngles.x <= rotationLimitX && transform.eulerAngles.x >= -1)
                {
                    Vector3 newRotation = new Vector3(transform.eulerAngles.x + rotationSpeedX, transform.eulerAngles.y, transform.eulerAngles.z);

                    transform.eulerAngles = newRotation;
                }
            }
            else if (sKeyPressed)
            {
                if (transform.eulerAngles.x <= 360 && transform.eulerAngles.x >= (360 - rotationLimitX) || transform.eulerAngles.x <= 90 && transform.eulerAngles.x >= -1)
                {
                    Vector3 newRotation = new Vector3(transform.eulerAngles.x - rotationSpeedX, transform.eulerAngles.y, transform.eulerAngles.z);

                    transform.eulerAngles = newRotation;
                }
            }
        }
    }

    private void OnPause(bool isPaused)
    {
        transform.eulerAngles = new Vector3(0,0,0);
        gamePaused = isPaused;
    }
}