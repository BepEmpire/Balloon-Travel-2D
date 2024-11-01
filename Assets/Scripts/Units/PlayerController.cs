using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float floatForce = 5.0f;
    [SerializeField] private float maxHeight = 4.0f;
    [SerializeField] private float groundLevel = -3.9f;
    private Rigidbody2D _balloonRb;

    private void Start()
    {
        _balloonRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < maxHeight)
        {
            _balloonRb.velocity = new Vector2(_balloonRb.velocity.x, floatForce);
        }
        
        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
            _balloonRb.velocity = Vector2.zero;
        }
        else if (transform.position.y < groundLevel)
        {
            transform.position = new Vector3(transform.position.x, groundLevel, transform.position.z);
            _balloonRb.velocity = Vector2.zero;
        }
    }
}
