using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;
	public float flyingHeight;
	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();

		target = Waypoints.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position + Vector3.up * flyingHeight;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (vector2DDistance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives = PlayerStats.Lives - enemy.damage;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
	
	private float vector2DDistance (Vector3 v1, Vector3 v2)
	{
		float xDiff = v1.x - v2.x;
		float zDiff = v1.z - v2.z;
		return Mathf.Sqrt((xDiff * xDiff) + (zDiff * zDiff));
	}

}