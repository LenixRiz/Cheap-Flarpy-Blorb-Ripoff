using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

    public LogicScript logicScript;
    public BirdScript birdScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdScript = GameObject.FindFirstObjectByType<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && birdScript.birdIsAlive != false)
        {
            logicScript.AddScore(1);
        }
    }
}
