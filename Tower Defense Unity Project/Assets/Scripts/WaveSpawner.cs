using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public GameObject simple; //b
	public GameObject fast; //f
	public GameObject tough; //t
	public GameObject flying; //a
	public GameObject flyingFast; //s
	public GameObject flyingTank; //d
	
	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	public Text waveCountdownText;

	private int waveIndex = 0;

	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];
		string enemyQueu = (string)wave.DecodeEnemyQueu();
		for (int i = 0; i < enemyQueu.Length; i++)
		{
			SpawnEnemy(enemyQueu.Substring(i,1));
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;

		if (waveIndex == waves.Length)
		{
			Debug.Log("LEVEL WON!");
			this.enabled = false;
		}
	}

	void SpawnEnemy (string enemy)
	{
		//switch case
		//Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		switch(enemy)
		{
			case "b":
				Instantiate(simple, spawnPoint.position, spawnPoint.rotation);
				break;
			case "f":
				Instantiate(fast, spawnPoint.position, spawnPoint.rotation);
				break;
			case "t":
				Instantiate(tough, spawnPoint.position, spawnPoint.rotation);
				break;
			case "a":
				Instantiate(flying, spawnPoint.position, spawnPoint.rotation);
				break;
			case "s":
				Instantiate(flyingFast, spawnPoint.position, spawnPoint.rotation);
				break;
			case "d":
				Instantiate(flyingTank, spawnPoint.position, spawnPoint.rotation);
				break;
			// default:
				// Debug.Log(enemy);
		}
		EnemiesAlive++;
	}

}