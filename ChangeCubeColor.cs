using Unity.VisualScripting;
using UnityEngine;

public class ChangeCubeColor : MonoBehaviour
{
    private Renderer cubeRenderer;
    public PlayerMovement playerMovement;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeColor(GetRandomColor());
        }
    }

    Color GetRandomColor()
    {
        Color[] colors = { Color.red, Color.yellow, Color.blue, Color.white };
        return colors[Random.Range(0, colors.Length)];
    }

    void ChangeColor(Color newColor)
    {
        cubeRenderer.material.color = newColor;

        if (newColor == Color.red)
        {
            Debug.Log("禁止前进");
            playerMovement.DisableJump();

        }
        if (newColor == Color.yellow|| newColor == Color.white)
        {
            playerMovement.all();
        }
            


        if (newColor == Color.blue ) 
        {
            Debug.Log("请向前进");
            playerMovement.EnableJump();
        }

    }
}
