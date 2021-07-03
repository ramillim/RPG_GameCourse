using System;
using UnityEngine;

public class FlippyBoxWin : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
            GetComponentInParent<FlippyBoxMiniGamePanel>().Win();
    }
}