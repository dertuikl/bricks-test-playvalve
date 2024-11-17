using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 500f;
    
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 force = Vector2.zero;
        force.x = 0.2f;
        force.y = -1;

        Rigidbody.AddForce(force.normalized * speed);
    }
}
