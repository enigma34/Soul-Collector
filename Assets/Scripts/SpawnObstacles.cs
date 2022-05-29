using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    //[SerializeField]
    //GameObject obstacle;
    [SerializeField]
    GameObject[] spawnObjectsList = new GameObject[3];

    [SerializeField]
    float maxX, minX, maxY, minY;

    [SerializeField]
    float timeBetweenSpawn; 
    
    float spawnTime;
    int obstacleCount, ghostCount, superPowerCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }   
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        int spwanObjectIndex = Random.Range(0, spawnObjectsList.Length);
        GameObject obstacle = spawnObjectsList[spwanObjectIndex];
        //GameObject obstacle = spawnObjectsList[1];

        if (obstacle.gameObject.tag == "Ghost")
        {
            Debug.Log("Ghost");
        }
        //Debug.Log($"Index of random object selected to spawn is: {spwanObjectIndex}\n");
        //Debug.Log($"Random object selected to spawn is: {obstacle.name}");

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
