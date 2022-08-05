using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpboost;
    private Rigidbody2D linkToRigidbody;
    private int countOfJumps = 1;
    private int health {get;set;}
    private void Movement(Rigidbody2D rigidbody){
        float velocityOfPlayerX = Input.GetAxisRaw("Horizontal") * speed;
        float velocityOfPlayerY = 0f;
        if(Input.GetKeyDown("space") && countOfJumps > 0)
        {
            velocityOfPlayerY = jumpboost;
        }
        var playerDirection = new Vector2(velocityOfPlayerX,velocityOfPlayerY);
        rigidbody.velocity = playerDirection;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        linkToRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(linkToRigidbody);
    }
}
