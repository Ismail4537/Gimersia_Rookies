using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        // Perbaikan: Cek kondisi reposisi dengan lebih akurat
        if (movement > startPos + (length / 2))
        {
            startPos += length;
        }
        else if (movement < startPos - (length / 2))
        {
            startPos -= length;
        }
    }
}