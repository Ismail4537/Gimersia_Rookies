using Unity.Cinemachine;
using UnityEngine;

public class paralaxYFollow : MonoBehaviour
{
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector2(transform.position.x, target.position.y);
        }
        else
        {
            Debug.LogWarning("ParallaxYFollow: Target is not assigned.");
        }
    }

    public void changeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
