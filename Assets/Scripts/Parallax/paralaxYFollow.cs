using UnityEngine;

public class paralaxYFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // yOffset = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector2(transform.position.x, target.position.y);
        }
    }
}
