using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> grounds;

    [SerializeField] private Transform lastGround;

    private void OnEnable()
    {
        Player.playerEnterArea += SpawnNewGround;
    }

    private void OnDisable()
    {
        Player.playerEnterArea -= SpawnNewGround;
    }

    private void SpawnNewGround()
    {
        GameObject newLast = Instantiate(grounds[0],new Vector3(0,-100f,lastGround.position.z + 30f), Quaternion.identity);
        lastGround = newLast.transform;
    }
}
