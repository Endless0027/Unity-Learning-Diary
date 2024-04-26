using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // 玩家对象的Transform
    public Vector3 offset; // 摄像机相对于玩家的偏移量

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = targetPosition + offset;
        }
    }
}
