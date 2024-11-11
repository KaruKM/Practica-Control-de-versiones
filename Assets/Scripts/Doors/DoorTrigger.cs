using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : DoorOpeningBehaviour
{
    [SerializeField] SwitchBehaviour trigger;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        trigger.RegisterFunctionToCall(Trigger);
    }

    private void Trigger(bool active, SwitchBehaviour sender)
    {
        door.Switch();
    }
}
