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

        // added small delay for dramatic effect
        yield return new WaitForSeconds(0.15f);
        transform.parent.GetComponent<PatrolBot>().patrolSpeed = 0;

        // getting caught special effects should go here

        yield return new WaitForSeconds(2.35f);
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
    }
}
