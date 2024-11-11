using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTT : DoorOpeningBehaviour
{
    [SerializeField]float timer, openedTime;
    [SerializeField] SwitchBehaviour trigger;

    protected override void Start()
    {
        base.Start();
        trigger.RegisterFunctionToCall(OnTriggerActivate);
    }

    void OnTriggerActivate(bool active, SwitchBehaviour sender)
    {
        if (!door.IsOpen())
        {
            door.Open();
            timer = 0;
        }
    }
    void Update()
    {
        if (door.IsOpen()) 
        { 
            timer += Time.deltaTime;
            if (timer >= openedTime)
            {
                door.Close();
                trigger.Activate(false);
            }
        }
    }
}