using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("yellow key obtained");

            // tell player object that item has been obtained
            other.gameObject.GetComponent<Inventory>().AddItem(gameObject.name);

            // disappear
            gameObject.SetActive(false);
        }
    }
    
}
