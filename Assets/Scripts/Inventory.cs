using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a class unique to the player in this game
// contains custom variables unique to this game
public class Inventory : MonoBehaviour
{
    // item id, bool: true if in player possession
    public Dictionary<string, bool> playerInventory;

    void Start()
    {
        // dictionary of items, for now keycards
        playerInventory = new Dictionary<string, bool>();
    }

    public void AddItem(string name)
    {
        playerInventory.Add(name, true);
    }



}
