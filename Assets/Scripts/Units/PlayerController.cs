using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float floatForce = 5.0f;
    [SerializeField] private float maxHeight = 4.0f;
    [SerializeField] private float groundLevel = -3.9f;
    private Rigidbody2D _balloonRb;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _skins;

    private void Start()
    {
        _balloonRb = GetComponent<Rigidbody2D>();
        
        int skinId = SkinManager.Instance.GetCurrentSkinId();
        _spriteRenderer.sprite = _skins[skinId];
    }
    
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlayerJump();
        }
        
        KeepBoundaries();
    }

    public void PlayerJump()
    { 
        _balloonRb.velocity = new Vector2(_balloonRb.velocity.x, floatForce);
    }

    private void KeepBoundaries()
    {
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
