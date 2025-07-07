using System.Collections.Generic;
using UnityEngine;

// Attach this script to any GameObject (e.g., Player)
public class SimpleInventory : MonoBehaviour
{
    // Item class to represent individual inventory items
    [System.Serializable]
    public class Item
    {
        public string name;
        public int id;
        public int quantity;

        public Item(string name, int id, int quantity = 1)
        {
            this.name = name;
            this.id = id;
            this.quantity = quantity;
        }
    }

    // List to store all items in the inventory
    private List<Item> inventory = new List<Item>();

    void Start()
    {
        // Add some example items on start
        AddItem("Sword", 0);
        AddItem("Health Potion", 1);
        AddItem("Health Potion", 1);
        PrintInventory();
    }

    // Adds an item to the inventory
    public void AddItem(string name, int id)
    {
        // Check if the item already exists
        foreach (Item item in inventory)
        {
            if (item.id == id)
            {
                item.quantity++;
                Debug.Log($"{name} already exists. Increased quantity to {item.quantity}");
                return;
            }
        }

        // Add new item
        Item newItem = new Item(name, id);
        inventory.Add(newItem);
        Debug.Log($"{name} added to inventory.");
    }

    // Prints all items in the inventory
    public void PrintInventory()
    {
        Debug.Log("=== Inventory ===");
        foreach (Item item in inventory)
        {
            Debug.Log($"- {item.name} x{item.quantity}");
        }
    }
}
