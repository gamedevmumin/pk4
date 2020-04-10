using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameEvent statChange;

    [SerializeField]
    PlayerStats stats;

    IMovement movementController;
    IJumpingController jumpingController;

    Vector2 movementInput;

    bool isRight = true;

    Rigidbody2D rb;

    SpriteRenderer sR;

    Animator anim;

    [SerializeField]
    CameraShake cS;

    private void Awake()
    {
        movementController = GetComponent<IMovement>();
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        jumpingController = GetComponent<IJumpingController>();
        cS = GameObject.Find("CameraShake").GetComponent<CameraShake>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovement();
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Upgraded", stats.upgraded);
    }

    private void FixedUpdate()
    {
        movementController.Move(movementInput, stats.speed);
    }

    protected IEnumerator Blink()
    {
        sR.material.SetFloat("_FlashAmount", 1f);
        yield return new WaitForSeconds(0.05f);
        sR.material.SetFloat("_FlashAmount", 0f);
    }

    void ManageMovement()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), movementInput.y);
         jumpingController.ManageJumping();
        if ((rb.velocity.x < 0 && isRight) || (rb.velocity.x > 0 && !isRight))
            Flip();
    }

    void Flip()
    {
        isRight = !isRight;    
        transform.Rotate(new Vector3(0f, 180f));
    }

    public void TakeDamage(int damage)
    {

        AudioManager.instance.PlaySound("Hurt2");
        StartCoroutine(Blink());
        cS.Shake(0.035f, 0.03f);
        stats.currentHP -= damage;
        statChange.Raise();
    }


}
