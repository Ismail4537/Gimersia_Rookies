using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInputController pic;
    public Rigidbody2D rb2D;
    [SerializeField] GroundDetector gd;
    private bool isGrounded = false;
    private float turnFactor = 10f;
    private float jumpForce = 5f;
    private bool terrainContact = false;
    public float rotat;


    // Awake is called when the script instance is being loaded
    protected void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pic = GetComponent<PlayerInputController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        MusicManager.instance.PlayMusicTrack("test", 1f);
    }

    // Update is called once per frame
    protected void Update()
    {

    }

    protected void FixedUpdate()
    {
        Spin();
        checkGround();
        rotat = Mathf.Round(transform.eulerAngles.z);
    }
    public void Spin()
    {
        if (pic.dir.x == 0)
        {
            rb2D.angularVelocity = Mathf.Clamp(rb2D.angularVelocity, -100f, 100f);
            return;
        }
        if (isGrounded || terrainContact) return;
        rb2D.angularVelocity -= pic.dir.x * turnFactor;
        rb2D.angularVelocity = Mathf.Clamp(rb2D.angularVelocity, -250f, 250f);
        rb2D.linearVelocity += new Vector2(0.01f, 0.01f);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void checkGround()
    {
        isGrounded = gd.isContact();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            terrainContact = true;
            if (transform.eulerAngles.z <= 300 && transform.eulerAngles.z >= 60 && !isGrounded)
            {
                SFXManager.instance.PlayClip3D("test", transform.position, 1.0f);
                Debug.Log("OW");
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            terrainContact = false;
        }
    }
}
