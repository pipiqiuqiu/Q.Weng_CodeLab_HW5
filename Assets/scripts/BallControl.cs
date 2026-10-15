using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class BallMove : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D mybody;
    private InputAction leftClick;
    private bool startGame = false;
    public TMP_Text scoreText;
    public int score = 0;
    void Start()
    {
        leftClick = InputSystem.actions.FindAction("LeftClick");
    }


    void Update()
    {
        if (leftClick.WasReleasedThisFrame() && startGame == false)
        {
            startGame = true;
        }

        if (startGame == true)
        {
            MoveBall();
        }
    }

    void MoveBall()
    {
        //move the ball's rigit body by the velocity
        //mybody.MovePosition(transform.position + velocity * Time.deltaTime);
        mybody.MovePosition(mybody.position + velocity * Time.fixedDeltaTime);
    }

    void BounceBallY()
    {
        velocity.y = -velocity.y;
    }
    void BounceBallX()
    {
        velocity.x = -velocity.x;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "UpperWall")
        {
            BounceBallY();
        }
        if (other.gameObject.tag == "SideWall")
        {
            BounceBallX();
        }

        if (other.gameObject.tag == "Brick")
        {
            score++;
            scoreText.text = score.ToString();
            BounceBallY();
            Destroy(other.gameObject);
        }
    }
}
