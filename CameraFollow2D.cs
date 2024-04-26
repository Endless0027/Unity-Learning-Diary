using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset; 

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = targetPosition + offset;
        }
    }
}
