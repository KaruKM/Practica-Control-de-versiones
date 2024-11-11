using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMultiTrigger : DoorOpeningBehaviour
{
    [SerializeField] SwitchBehaviour[] trigger;
    int activatedTriggers;

    protected override void Start()
    {
        base.Start();
        activatedTriggers = 0;

        int counter;

        for (counter = 0; counter < trigger.Length; counter++)
        {
            trigger[counter].RegisterFunctionToCall(OnTriggerActivation);
        }
    }
    private void OnTriggerActivation(bool active, SwitchBehaviour sender)
    {
        if (active)
        {
            if(sender == trigger[activatedTriggers]) 
            {
                activatedTriggers++;
            }
            else
            {
                //Restablecer triggers activos
                activatedTriggers = 0;
                //Aviso a todos los triggers del error
                int counter;
                for (counter = 0; counter < trigger.Length; counter++)
                {
                    trigger[counter].Error();
                }
            }            
        }
        else
        {            
            activatedTriggers--;
            if (activatedTriggers < 0) 
            {
                activatedTriggers = 0;
            }
        }

        if(activatedTriggers == trigger.Length && !door.IsOpen())
        {
            door.Open();
        }
        else if(door.IsOpen() && activatedTriggers< trigger.Length)
        {
            door.Close();
        }
    }
}
