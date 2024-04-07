using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float lookSpeed = 2.0f;

    void Update()
    {
        // ��ȡ�������
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ���������������ƶ�����
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.y = 0; // ȷ��ֻ��ˮƽ�����ƶ�

        // �ƶ���ҽ�ɫ
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

        // ��ȡ�������
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // �������������ת��ҽ�ɫ
        transform.Rotate(Vector3.up, mouseX * lookSpeed);
        transform.Rotate(Vector3.right, -mouseY * lookSpeed);

        // ������ҽ�ɫ�ڴ�ֱ�����ϵ���ת�Ƕȣ����ⷭת
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, 0f, 15f);
        transform.localEulerAngles = currentRotation;

        Quaternion targetRotation = Quaternion.Euler(currentRotation.x, transform.localEulerAngles.y + mouseX * lookSpeed, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // �����10f�ǲ�ֵϵ�������Ը�����Ҫ����
    }
}

