using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleteme : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }
}
