using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    Item[] items;

    public Item GetItem(int index)
    {
        if (index < 0 || index >= items.Length)
        {
            return null;
        }
        else 
        {
            return items[index];
        }
    }
    public Item GetItem(string name)
    {
        for (int i = 0; i< items.Length; i++)
        {
           
            Item it = items[i];
            //Comprobar que no sea null
            if(it != null) 
            { 
                if(it.GetName() == name)
                {
                    return it;
                }
            }
        }
        return null;
    }
    public bool AddItem(Item newItem)
    {
        for (int i = 0;i< items.Length; i++)
        {
            if (items[i] == null)
            {
                //Hueco en el inventario
                items[i] = newItem;
                return true;
            }
        }
        return false;
    }
    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Length)
        {
            items[index] = null;
        }
    }
    public void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Item it = items[i];
            if (it != null)
            {
                if (it == item)
                {
                    return;
                }
            }
        }
    }        
    public void RemoveItem(string name)
    {
        for (int i = 0; i < items.Length; i++)
        {

            Item it = items[i];
            //Comprobar que no sea null
            if (it != null)
            {
                if (it.GetName() == name)
                {
                    return;
                }
            }
        }
        return;
    }
    public void UseItem(string name)
    {
        Item it = GetItem(name);
        if (it != null)
        {
            it.Use();
        }
    }
    public void UseItem(int index)
    {
        if (index > 0 && index < items.Length)
        {
            if (items[index] != null)
            {
                items[index].Use();
            }
        }
    }

    public string PrintAllItems()
    {
        string returnedString = "";

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                returnedString = returnedString + "Vacío" + "";
            }
            else
            {
                returnedString = returnedString + items[i].GetName() + "";
            }
        }
        return returnedString;
    }
    public bool HasItem(string name) 
    {
        for (int i = 0; i < items.Length; i = i + 1)
        {
            if (items[i] != null)
            {
                if (items[i].GetName() == name)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool HasItem(Item item)
    {
        return HasItem(item.GetName());
    }
}