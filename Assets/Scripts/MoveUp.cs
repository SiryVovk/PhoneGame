using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private float yEndPos = 0;
    private void Awake()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
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
}
