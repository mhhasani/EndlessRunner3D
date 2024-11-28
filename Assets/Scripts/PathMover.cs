using UnityEngine;

public class PathMover : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // حرکت مسیر به سمت عقب
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // حذف مسیر قدیمی
        if (transform.position.z < -20f)
        {
            Destroy(gameObject);
        }
    }
}
