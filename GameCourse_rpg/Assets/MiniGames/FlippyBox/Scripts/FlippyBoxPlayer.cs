using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class FlippyBoxPlayer : MonoBehaviour, IRestart
{
    Rigidbody2D _rigidbody;
    float GrowTime => FlippyBoxMiniGamePanel.Instance.currentSettings.GrowTime;
    [SerializeField] float _spinSpeed = 2f;
    Vector2 JumpVelocity => FlippyBoxMiniGamePanel.Instance.currentSettings.JumpVelocity;
    Vector3 _startingPosition;
    Quaternion _startingRotation;
    float _elapsed;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startingPosition = transform.position;
        _startingRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            _rigidbody.velocity = JumpVelocity;
        transform.Rotate(0f, 0f, Time.deltaTime * _spinSpeed);

        _elapsed += Time.deltaTime;
        float size = Mathf.Lerp(1f, 2f, _elapsed / GrowTime);
        transform.localScale = new Vector3(size, size, 1f);
    }

    public void Restart()
    {
        transform.position = _startingPosition;
        transform.rotation = _startingRotation;
        _elapsed = 0f;
        transform.localScale = Vector3.one;
        GetComponent<SpriteRenderer>().color = FlippyBoxMiniGamePanel.Instance.currentSettings.PlayerColor;
    }
}
