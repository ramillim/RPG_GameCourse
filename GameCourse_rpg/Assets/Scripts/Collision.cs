using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.collider.name == "Dave")
        {
            Debug.Log("Damn the cops!");
        }
        else if(other.collider.name == "chong")
        {
            Debug.Log("Daves's not here man.");
        }
    }
}
