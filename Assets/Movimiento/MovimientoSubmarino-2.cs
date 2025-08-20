using UnityEngine;

public class MovimientoSubmarino : MonoBehaviour
{
    public float velocidad = 5f;          // Velocidad de movimiento
    public float sensibilidad = 2f;       // Sensibilidad del ratón
    public float velocidadVertical = 3f;  // Velocidad para subir/bajar

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Bloquea y oculta el cursor para controlar con el ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MovimientoLibre();
        RotacionCamara();
    }

    void MovimientoLibre()
    {
        float movX = Input.GetAxis("Horizontal"); // A/D
        float movZ = Input.GetAxis("Vertical");   // W/S
        float movY = 0f;

        if (Input.GetKey(KeyCode.E)) movY = 1f;  // Subir
        if (Input.GetKey(KeyCode.Q)) movY = -1f; // Bajar

        Vector3 movimiento = transform.right * movX + transform.up * movY * velocidadVertical + transform.forward * movZ;
        controller.Move(movimiento * velocidad * Time.deltaTime);
    }

    void RotacionCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

        rotacionY += mouseX;
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -80f, 80f); // Limita inclinación vertical

        transform.localRotation = Quaternion.Euler(rotacionX, rotacionY, 0f);
    }
}
