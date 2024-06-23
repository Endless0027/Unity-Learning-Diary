using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] new Rigidbody rigidbody;
     bool canJump = true;
    bool canMove = true;

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            
            if ( Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                rigidbody.AddForce(new Vector3(10, 0, Input.GetAxis("Vertical")) * moveSpeed);
                rigidbody.AddForce(Vector3.up * jumpSpeed);
                Debug.Log("按下了其他键");
            }
          
        }
        if (canJump == true)
        {
            
            if ( Input.GetKeyDown(KeyCode.W) ) 
            {
                rigidbody.AddForce(new Vector3(5, 0, Input.GetAxis("Vertical")) * moveSpeed);
                rigidbody.AddForce(Vector3.up * jumpSpeed);
                Debug.Log("W键被按下");
            }
        }

    }

    public void DisableJump()
    {
        canJump = false;
        canMove = true;

    }
    public void all()
    {
        canJump = true;
        canMove = true;
    }

    public void EnableJump()
    {
        canJump = true;
        canMove = false;

    }
}

