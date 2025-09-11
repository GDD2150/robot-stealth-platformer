using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public GameObject keycard;
    public string nextScene;


    void Start()
    {
        GetComponent<SpriteRenderer>().color = keycard.GetComponent<SpriteRenderer>().color;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("here");
            if(other.gameObject.GetComponent<Inventory>().playerInventory.TryGetValue(keycard.name, out bool value))
            {
                // load next scene
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
