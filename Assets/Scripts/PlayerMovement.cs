using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f; // سرعت حرکت به جلو
    public float sidewaysSpeed = 5f; // سرعت حرکت به چپ و راست

    void Update()
    {
        // حرکت به جلو
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // حرکت به چپ و راست با کلیدهای A و D
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * sidewaysSpeed * Time.deltaTime);
    }
}
