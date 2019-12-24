using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject PipePrefab;
    [SerializeField] private GameObject PipeDetectorPrefab;
    [SerializeField] private LevelController theLevel;
    [SerializeField] private float minPipePos = -10;
    [SerializeField] private float maxPipePos = 10;
    public float pipeGenerateTime;
    public float spawnPositionY;
    private float pipeGenerateCounter;

    void Update()
    {
        if (theLevel.isStart)
        {
            if (pipeGenerateCounter >= 0)
                pipeGenerateCounter -= Time.fixedDeltaTime;
            else
            {
                CreatePipe();
                pipeGenerateCounter = pipeGenerateTime;
            }
        }
    }

    void CreatePipe()
    {
        float randomY = Random.Range(-spawnPositionY, spawnPositionY);
        Debug.Log(randomY);
        GameObject thePipeObject = Instantiate(PipePrefab, new Vector3(maxPipePos, randomY, transform.position.z), Quaternion.identity);
        thePipeObject.transform.SetParent(this.transform);
        PipeController thePipe = thePipeObject.GetComponent<PipeController>();
        thePipe.minPipePos = minPipePos;
    }

}
