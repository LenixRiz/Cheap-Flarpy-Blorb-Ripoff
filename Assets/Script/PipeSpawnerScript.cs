using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 5;
    private float timer = 0;
    private float heightOffset = 10;
    public float moveSpeed = 8;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        float minHeight = transform.position.y - heightOffset;
        float maxHeight = transform.position.y + heightOffset;
        float spawnY = Random.Range(minHeight, maxHeight);

        Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, transform.position.z);
        
        Instantiate(pipe, spawnPosition, transform.rotation);
        Debug.Log("Pipe spawned.");
    }
}
