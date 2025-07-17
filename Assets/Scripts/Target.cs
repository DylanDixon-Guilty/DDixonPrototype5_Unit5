using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    public int PointValue; // Set to 15 in Unity (-15 for bad prop)
    public ParticleSystem ExplosionParticle;

    private Rigidbody targetRb;
    private float minSpeed = 14f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4;
    private float ySpawnPosition = 4;
    private GameManager gameManager;

    private void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameManager.IsGameActive)
        {
            Instantiate(ExplosionParticle, transform.position, ExplosionParticle.transform.rotation);
            Destroy(gameObject);
            gameManager.UpdateScore(PointValue);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// Used in AddForce in start function to send a Good or Bad prop up into the air with a certain speed.
    /// </summary>
    private Vector3 RandomForce()
    {
        return Vector3.up* Random.Range(minSpeed, maxSpeed);
    }

    /// <summary>
    /// Used in AddTorque in Start function to make a Good or Bad prop rotate in a random direction.
    /// </summary>
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    /// <summary>
    /// Used in transform.position in Start function to spawn a good or bad prop somewhere on the Y axis.
    /// </summary>
    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPosition);
    }    
}
