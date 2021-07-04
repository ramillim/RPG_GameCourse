using UnityEngine;
[CreateAssetMenu(menuName = "MiniGame/Flippy Box Settings", fileName = "FlippyBoxSettings-")]
public class FlippyBoxMinigameSettings : ScriptableObject
{
    public float MovingBoxSpeed = 5f;
    public Vector2 JumpVelocity = Vector2.up + Vector2.right;
    public float GrowTime = 20f;
    public Color PlayerColor = Color.green;
}
