using System;
using Unity.Cinemachine;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInputController pic;
    public Rigidbody2D rb2D;
    ConstantForce2D cf;
    [SerializeField] CollideChecker chara, board;
    [SerializeField] CinemachineCamera CCCam;
    [SerializeField] GroundDetector gd;
    Vector2 startPos;
    float distanceTravelled = 0f;
    public bool isGrounded = false;
    public bool wasGrounded = false;
    float turnFactor = 10f;
    float jumpForce = 10f;
    bool terrainContact = false;
    float boosterMeterMax = 100f;
    public float boosterMeterCur = 0f;
    public float maxVelocity = 200f;
    float smoothVel;
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pic = GetComponent<PlayerInputController>();
        cf = GetComponent<ConstantForce2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        MusicManager.instance.PlayMusicTrack("test", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        DisCount();
    }

    void FixedUpdate()
    {
        Movement();
        maxVelocityReset();
        checkGround();
        terrainContactChecker();
    }

    void DisCount()
    {
        distanceTravelled = Vector2.Distance(startPos, transform.position);
        HUDManager.instance.UpdateDistanceCounter(distanceTravelled);
    }

    public void Movement()
    {
        CCCam.Lens.OrthographicSize = Mathf.SmoothDamp(10, rb2D.linearVelocity.magnitude, ref smoothVel, 0.25f);
        if ((isGrounded || terrainContact) && !wasGrounded)
        {
            rb2D.linearVelocity = Vector2.ClampMagnitude(rb2D.linearVelocity, maxVelocity);
            rb2D.gravityScale = 2f;

            Vector2 baseDir = -transform.up;
            Quaternion raycastRotation = Quaternion.Euler(0f, 0f, 0f);
            Vector2 raycastDir = raycastRotation * baseDir;
            if (!Physics2D.Raycast(new Vector2(transform.position.x + 1, transform.position.y - 0.5f), raycastDir, 5f, LayerMask.GetMask("Terrain")))
            {
                cf.relativeForce = new Vector2(0f, 0f);
            }
            else
            {
                cf.relativeForce = new Vector2(0f, -rb2D.linearVelocity.magnitude * 10f);
            }

        }
        else
        {
            cf.relativeForce = new Vector2(0f, 0f);
            rb2D.gravityScale = 1f;
        }
        if (pic.dir.x == 0)
        {
            rb2D.angularVelocity = Mathf.Clamp(rb2D.angularVelocity, -100f, 100f);
            return;
        }
        rb2D.angularVelocity -= pic.dir.x * turnFactor;
        rb2D.angularVelocity = Mathf.Clamp(rb2D.angularVelocity, -250f, 250f);
    }

    // Test raycast

    // public float heigh = 2.5f;

    // void OnDrawGizmos()
    // {
    //     Vector2 baseDir = -transform.up;
    //     Quaternion raycastRotation = Quaternion.Euler(0f, 0f, 0f);
    //     Vector2 raycastDir = raycastRotation * baseDir;
    //     Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), raycastDir * heigh, Color.green);
    // }

    // Test raycast end

    public void Jump()
    {
        if (isGrounded)
        {
            cf.relativeForce = new Vector2(0f, 0f);
            wasGrounded = true;
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void checkGround()
    {
        isGrounded = gd.isContact();
        if (gd.isContact())
        {
            wasGrounded = false;
        }
        else
        {
            wasGrounded = true;
        }
    }

    public void updateBooster(float amount)
    {
        boosterMeterCur = Mathf.Clamp(amount, 0f, boosterMeterMax);
        Debug.Log("Booster Meter: " + boosterMeterCur);
        HUDManager.instance.UpdateBoosterMeter(boosterMeterCur);
    }

    public void useBooster()
    {
        if (boosterMeterCur == 100f && isGrounded)
        {
            maxVelocity = 250f;
            if (rb2D.linearVelocity.x < 0)
            {
                rb2D.linearVelocity *= -2f;
            }
            else
            {
                rb2D.linearVelocity *= 2f;
            }
            updateBooster(0);
        }
    }

    void maxVelocityReset()
    {
        if (maxVelocity > 200f)
        {
            maxVelocity -= Time.fixedDeltaTime * 10f;
        }
        if (maxVelocity < 200f)
        {
            maxVelocity = 200f;
        }
    }

    void terrainContactChecker()
    {
        if (board == null || chara == null)
        {
            return;
        }
        if (board.isCollide() || chara.isCollide())
        {
            terrainContact = true;
        }
        else
        {
            terrainContact = false;
        }
    }
}
