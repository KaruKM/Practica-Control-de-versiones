using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningBehaviour : MonoBehaviour
{
    protected DoorBehaviour door;
    protected virtual void Start()
    {
        door = GetComponent<DoorBehaviour>();
    }
}