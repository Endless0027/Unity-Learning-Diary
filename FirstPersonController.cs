using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float lookSpeed = 2.0f;

    void Update()
    {
        // 获取玩家输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 根据玩家输入计算移动方向
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.y = 0; // 确保只在水平方向移动

        // 移动玩家角色
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

        // 获取鼠标输入
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 根据鼠标输入旋转玩家角色
        transform.Rotate(Vector3.up, mouseX * lookSpeed);
        transform.Rotate(Vector3.right, -mouseY * lookSpeed);

        // 限制玩家角色在垂直方向上的旋转角度，避免翻转
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, 0f, 15f);
        transform.localEulerAngles = currentRotation;

        Quaternion targetRotation = Quaternion.Euler(currentRotation.x, transform.localEulerAngles.y + mouseX * lookSpeed, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // 这里的10f是插值系数，可以根据需要调整
    }
}

