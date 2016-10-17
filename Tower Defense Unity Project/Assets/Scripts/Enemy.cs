using UnityEngine;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float speed;

	public float health = 100;

	public int worth = 50;

	public GameObject deathEffect;

	void Start ()
	{
		speed = startSpeed;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;

		if (health <= 0)
		{
			Die();
		}
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(gameObject);
	}

}
