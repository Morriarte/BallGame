using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float groundedDrag;

    public bool CanMove;

    private Rigidbody rb;

    private float radius = 1.0f;
    private float movementX;
    private float movementY;

    [HideInInspector] public UnityEvent<Collider> onTriggerEnter;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.drag = groundedDrag;
        CanMove = true;
    }

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (onTriggerEnter != null) onTriggerEnter.Invoke(other);
    }

    private void Move()
    {
        Vector3 movement = new Vector3(-movementY, 0.0f, movementX);
        movement = Vector3.ClampMagnitude(movement, radius);

        rb.AddForce(movement * force);
    }

    private void CheckInput()
    {
        if (!CanMove) return;

        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
    }
}
