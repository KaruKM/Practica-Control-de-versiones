using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DoorBehaviour))]
public class DoorKeyItem : DoorOpeningBehaviour
{
    [SerializeField] string[] keysName;

    private void OnTriggerEnter(Collider other)
    {
        InventoryBehaviour inv = other.gameObject.GetComponent<InventoryBehaviour>();
        if(inv != null && HasAllItems(inv))
        {
            door.Open();
        }
    }

    bool HasAllItems(InventoryBehaviour inv)
    {
        for (int i=0; i < keysName.Length; i++)
        {
            if (!inv.HasItem(keysName[i]))
            {
                return false;
            }
        }
        return true;
    }
}