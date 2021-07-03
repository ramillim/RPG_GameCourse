using System.Drawing;
using UnityEngine;

public class FlippyBoxPlayer : MonoBehaviour, IRestart
{
    Rigidbody2D _rigidbody;
    [SerializeField] float growTime = 10f;
    [SerializeField] float _spinSpeed = 2f;
    [SerializeField] Vector2 _jumpVelocity = Vector2.up;
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
            _rigidbody.velocity = _jumpVelocity;
        transform.Rotate(0f, 0f, Time.deltaTime * _spinSpeed);

        _elapsed += Time.deltaTime;
        float size = Mathf.Lerp(1f, 2f, _elapsed / growTime);
        transform.localScale = new Vector3(size, size, 1f);
    }

    public void Restart()
    {
        transform.position = _startingPosition;
        transform.rotation = _startingRotation;
        _elapsed = 0f;
        transform.localScale = Vector3.one;
    }
}
