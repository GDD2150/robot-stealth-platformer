using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadLastLevel());
    }

    IEnumerator LoadLastLevel()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
    }
}
