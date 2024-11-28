using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // مرجع کاراکتر (Cube)
    public Vector3 offset; // فاصله دوربین از کاراکتر

    void LateUpdate()
    {
        // تنظیم موقعیت دوربین نسبت به کاراکتر
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
