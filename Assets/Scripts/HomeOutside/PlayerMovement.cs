
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private float moveSpeed;
    private float moveH, moveV;

   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;

       
            Flip();
    }
    private void FixedUpdate()
    {
        
            rb.linearVelocity = new Vector2(moveH, moveV);
      
    }

    private void Flip()
    {
        if (moveH > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveH < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
}
