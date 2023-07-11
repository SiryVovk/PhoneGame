using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private GameObject pickUp;

    [SerializeField] private float speed = 1;

    private float[] zPositions = new float[] {0.7f,0.6f,0.5f,0.4f};
    private float xRangeSpawn = 0.3f;
    private float ySpawnPos = 0.095f;
    private float yEndPos = 0;
    private int minNumberToSpawn = 3;
    private int maxNumberToSpawn = 4;

    private void Awake()
    {
        StartCoroutine(MoveUp());
        SpawnPickApp();
    }

    private IEnumerator MoveUp()
    {
        while (transform.position.y < yEndPos)
        {
            float currentY = transform.position.y;
            float yMovement = speed * Time.deltaTime;

            float newY = Mathf.Clamp(currentY + yMovement, currentY, yEndPos);

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, yEndPos, transform.position.z);
    }

    private void SpawnPickApp()
    {
        int toSpawn = Random.Range(minNumberToSpawn, maxNumberToSpawn + 1);

        for(int i = 0; i < toSpawn; i++)
        {
            float xPos = Random.Range(-xRangeSpawn, xRangeSpawn);
            Vector3 position = new Vector3(xPos, ySpawnPos, zPositions[i]);
            GameObject created = Instantiate(pickUp);
            created.transform.SetParent(transform);
            created.transform.localPosition = position;
        }
    }
}
