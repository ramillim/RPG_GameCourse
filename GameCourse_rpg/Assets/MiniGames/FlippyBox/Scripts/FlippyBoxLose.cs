using UnityEngine;

public class FlippyBoxLose : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
            GetComponentInParent<FlippyBoxMiniGamePanel>().Lose();
    }
}