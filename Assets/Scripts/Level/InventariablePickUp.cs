using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventariablePickUp : MonoBehaviour
{
    [SerializeField] string itemName;
    Item it;

    private void Start()
    {
        it = new Item();
        it.SetName(itemName);
    }

    private void OnTriggerEnter(Collider other)
    {
        InventoryBehaviour inv = other.gameObject.GetComponent<InventoryBehaviour>();

        if (inv != null)
        {
            inv.AddItem(it);

            Debug.Log(inv.HasItem(it));
            Debug.Log("Objeto: " + inv.HasItem("objeto"));
            Destroy(this.gameObject);
        }
    }
}