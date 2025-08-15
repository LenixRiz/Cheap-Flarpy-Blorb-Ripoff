using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public LogicScript logicScript;
    private PipeSpawnerScript pipeSpawnerScript;
    private float deadZone = -45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawnerScript = FindFirstObjectByType<PipeSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * Time.deltaTime * pipeSpawnerScript.moveSpeed);

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted.");
            Destroy(gameObject);
        }

    }
}
