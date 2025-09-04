using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this scene will save the name of the level the player loads into
// the intent is to attach this script to an object for each scene used for progression
// if you do load a previous scene, that scene will be "saved" for the player
public class SceneSave : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
    }

    
}
