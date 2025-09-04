using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// used by the patrol robots to catch the player
public class Detected : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // player death
            StartCoroutine(GameOver());
            
        }
    }   

    IEnumerator GameOver()
    {
        // disable player movement
        GameObject.Find("Player").GetComponent<PlayerMovement>().moveSpeed = 0;

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
    }
}
