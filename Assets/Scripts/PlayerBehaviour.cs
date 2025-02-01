using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 100f;
    public float jumpVelocity = 10f;
    public float distanceToGround = 0.1f;
    public float jumpInput = 0f;
    public float moneyInput = 0f;
    public float moneySpeed = 50f;
    public LayerMask groundLayer;
    public GameObject money;
    public GameManager gameManager;
    private Rigidbody _rb;
    private float _horizontalInput;
    private float _verticalInput;
    private CapsuleCollider _capsuleCollider;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }  
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        _verticalInput = Input.GetAxis("Vertical") * rotationSpeed;
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpInput = jumpVelocity;
        }

        if (Input.GetMouseButtonDown(0))
        {
            moneyInput = moneySpeed;
        }
    }

    void FixedUpdate()
    {
        if (moneyInput > 0)
        {
            GameObject newMoney = Instantiate(money, transform.position + new Vector3(1, 0, 0), transform.rotation) as GameObject;
            Rigidbody moneyRB = newMoney.GetComponent<Rigidbody>();
            moneyRB.velocity = transform.forward * moneyInput;
            moneyInput = 0f;
        }
        _rb.AddForce(Vector3.up * jumpInput, ForceMode.Impulse);
        jumpInput = 0f;
        Vector3 rotation = Vector3.up * _horizontalInput;
        Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(transform.position  + Vector3.forward * _verticalInput * Time.fixedDeltaTime);
        _rb.MoveRotation(angleRotation * _rb.rotation);
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_capsuleCollider.bounds.center.x, _capsuleCollider.bounds.min.y, _capsuleCollider.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_capsuleCollider.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fireball(Clone)")
        {
            gameManager.PlayerLifes--;
        }
    }
}
