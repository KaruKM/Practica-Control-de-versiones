using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTimed : DoorOpeningBehaviour
{
    [SerializeField] float openedTime;
    [SerializeField] float closedTime;
    float timeCounter;

    protected override void Start()
    {
        base.Start();
        timeCounter = 0;
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
        if (door.IsOpen())
        {
            if (timeCounter > openedTime)
            {
                door.Close();
                timeCounter = 0;
            }
        }
        else
        {
            if (timeCounter > closedTime)
            {
                door.Open();
                timeCounter = 0;
            }
    }
        }
}
