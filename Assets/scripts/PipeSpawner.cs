using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeSpawner : MonoBehaviour {

	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject pipe;
	public GameObject coin;
	public float[] heights;
	
	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .		
	}

    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnPipe), spawnDelay, spawnTime);
        InvokeRepeating(nameof(SpawnCoin), 2f, 2f);
    }
	
	
	void SpawnPipe ()
	{
		int heightIndex = Random.Range(0, heights.Length);
		Vector2 pos = new Vector2(transform.position.x, heights[heightIndex]);

		Instantiate(pipe, pos, transform.rotation);
	}
	
	void SpawnCoin ()
	{
		int heightIndex = Random.Range(0, heights.Length);
		Vector2 pos = new Vector2(transform.position.x, heights[heightIndex]);

		Instantiate(coin, pos, transform.rotation);
	}

	public void GameOver()
	{
		CancelInvoke(nameof(SpawnPipe));
		CancelInvoke(nameof(SpawnCoin));
	}
}
