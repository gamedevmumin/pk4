using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : Enemy
{

	Rigidbody2D rb;
	[SerializeField]
	float speed = 10f;

	bool isDead = false;

	enum Direction { RIGHT, LEFT };
	Direction direction = Direction.RIGHT;

	[SerializeField]
	int maxHP;
	int currentHP;

	[SerializeField]
	CameraShake cS;

	protected SpriteRenderer sR;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		sR = GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start()
	{
		currentHP = maxHP;
		double dir = Random.Range(-1f, 1f);
		if (dir > 0f)
		{
			direction = Direction.RIGHT;
		}
		else
		{
			transform.Rotate(0f, 180f, 0f);
			direction = Direction.LEFT;
		}
		isDead = false;
		ChooseDirection();
	}

	private void FixedUpdate()
	{
		if (!isDead) ChooseDirection();
	}

	void Update()
	{

		if (currentHP <= 0 && !isDead)
		{
			Die();
		}
	}

	void ChooseDirection()
	{
		if (direction == Direction.RIGHT) rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
		else if (direction == Direction.LEFT) rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, rb.velocity.y);
	}

	public void ChangeDirection()
	{
		if (direction == Direction.RIGHT) direction = Direction.LEFT;
		else direction = Direction.RIGHT;
		transform.Rotate(0f, 180f, 0f);
		ChooseDirection();
	}

	protected IEnumerator Blink()
	{
		sR.material.SetFloat("_FlashAmount", 1f);
		yield return new WaitForSeconds(0.05f);
		sR.material.SetFloat("_FlashAmount", 0f);
	}

	public override void TakeDamage(int damage)
	{
		if (!isDead)
		{
			currentHP -= damage;
			if (currentHP > 0f) AudioManager.instance.PlaySound("Hurt");
			cS.Shake(0.03f, 0.03f);
			StartCoroutine("Blink");
		}

	}

	public void Die()
	{
		if (!isDead)
		{
			isDead = true;
			AudioManager.instance.PlaySound("Death");
			Drop();
			Destroy(gameObject);
		}
	}
	[SerializeField]
	List<Collectable> collectables;

	void Drop()
	{
		int amount = Random.Range(1, 1);
		int whichOne = Random.Range(0, collectables.Count);

		Rigidbody2D rb1 = Instantiate(collectables[0].gameObject, transform.position, Quaternion.Euler(Vector3.zero)).GetComponent<Rigidbody2D>();
		rb1.AddForce(new Vector2(Random.Range(-3f, 3f) * 1
			, Random.Range(0f, 3f) * 1), ForceMode2D.Impulse);

		for (int i = 0; i < amount; i++)
		{
			Rigidbody2D rb = Instantiate(collectables[whichOne].gameObject, transform.position, Quaternion.Euler(Vector3.zero)).GetComponent<Rigidbody2D>();
			rb.AddForce(new Vector2(Random.Range(-3f, 3f) * 1
				, Random.Range(0f, 3f) * 1), ForceMode2D.Impulse);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.CompareTag("Player") && !isDead)
		{

			coll.GetComponent<PlayerController>().TakeDamage(10);
		}
		if(coll.CompareTag("DirectionChanger"))
		{
			ChangeDirection();
		}
	}

}
