using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectrocutePlayer : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerSprite = other.gameObject.GetComponent<SpriteRenderer>();
            other.gameObject.GetComponent<PlayerMovement>().moveSpeed = 0;
            StartCoroutine(Electrocution());
        }
    }

    IEnumerator Electrocution()
    {
        float duration = .0255f;
        float i = 0;

        // last minute jank, don't judge!
        while(i < duration)
        {
            playerSprite.color = Color.blue;
            yield return new WaitForSeconds(0.1f);
            playerSprite.color = Color.white;
            i += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            i += Time.deltaTime;
            Debug.Log(i);
        }
        SceneManager.LoadScene("lose screen");
    }
}
