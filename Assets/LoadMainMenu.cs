using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(BeginLoadMainMenu());
    }

    IEnumerator BeginLoadMainMenu()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
        SceneManager.LoadScene("Level_1");
    }
}
