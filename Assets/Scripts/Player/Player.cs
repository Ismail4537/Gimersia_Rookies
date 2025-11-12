using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerInputController pic;
    Rigidbody2D rb2D;
    ConstantForce2D cf;
    [SerializeField] CollideChecker chara, board;
    [SerializeField] CinemachineCamera CCCam;
    [SerializeField] GroundDetector gd;
    Vector2 startPos;
    public bool isGrounded = false;
    public bool isFell = false;
    float distanceTravelled = 0f;
    bool wasGrounded = false;
    bool canControlled = true;
    float turnFactor = 10f;
    float jumpForce = 10f;
    bool terrainContact = false;
    float boosterMeterMax = 100f;
    float boosterMeterCur = 0f;
    float maxVelocity = 80f;
    float smoothVel;
    float boostDuration = 5f;
    float boostTimer;
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
        GameUIManager.instance.UpdateBoosterMeter(boosterMeterCur);
    }

    // Update is called once per frame
    void Update()
    {
        DisCount();
    }

    void FixedUpdate()
    {
        camMovement();
        Movement();
        checkGround();
        terrainContactChecker();
    }

    void DisCount()
    {
        if (isFell)
        {
            return;
        }
        if (distanceTravelled < Vector2.Distance(startPos, transform.position))
        {
            distanceTravelled = Vector2.Distance(startPos, transform.position);
            GameUIManager.instance.UpdateDistanceCounter(distanceTravelled);
        }
    }

    public void Movement()
    {
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
            rb2D.linearVelocity = Vector2.ClampMagnitude(rb2D.linearVelocity, maxVelocity);
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

    public void changeCamTarget(Transform newTarget)
    {
        CCCam.Follow = newTarget;
    }

    public Vector2 getVelocity()
    {
        return rb2D.linearVelocity;
    }

    public float getMaxSpeed()
    {
        return maxVelocity;
    }

    public bool getControllable()
    {
        return canControlled;
    }

    public bool setControllable(bool state)
    {
        canControlled = state;
        return canControlled;
    }

    void camMovement()
    {
        if (canControlled)
        {
            CCCam.Lens.OrthographicSize = Mathf.SmoothDamp(20, rb2D.linearVelocity.magnitude, ref smoothVel, 0.2f);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            SFXManager.instance.PlayClip3D("HitSnow", transform.position, 1f);
            cf.relativeForce = new Vector2(0f, 0f);
            isGrounded = false;
            wasGrounded = true;
            float playerRotation = transform.eulerAngles.z;
            Vector2 jumpDir = new Vector2(-Mathf.Sin(playerRotation * Mathf.Deg2Rad), Mathf.Cos(playerRotation * Mathf.Deg2Rad));
            rb2D.AddForce(jumpDir * (jumpForce + (rb2D.linearVelocity.magnitude * 0.25f)), ForceMode2D.Impulse);
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
        GameUIManager.instance.UpdateBoosterMeter(boosterMeterCur);
    }

    public void useBooster()
    {
        if (boosterMeterCur == 100f && isGrounded)
        {
            SFXManager.instance.PlayClip2D("Boosting", 0.25f);
            StartCoroutine(boostCountdown());
            updateBooster(0);
        }
    }

    IEnumerator boostCountdown()
    {
        boostTimer = boostDuration;
        while (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            if (isGrounded)
            {
                rb2D.AddForce(new Vector2(0.5f, 0f), ForceMode2D.Impulse);
            }
            yield return null;
        }
        StopCoroutine(boostCountdown());
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
