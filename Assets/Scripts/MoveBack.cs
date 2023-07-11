using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;

    private float deletePoint = -40;

    private void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z <= deletePoint)
            Destroy(gameObject);
    }
}
