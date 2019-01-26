using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPoint : MonoBehaviour
{
    public enum Direction
    {
        LEFT,
        RIGHT  
    }

    public int chambersLimit;
    public float offset = 1.1f;
    public Direction direction;
    public GameObject supplyChamberPrefab;

    public void OnBuildButton()
    {
        Instantiate(supplyChamberPrefab, transform.position, Quaternion.identity);
        transform.Translate((direction == Direction.LEFT ? -1 : 1) * offset, 0, 0);
    }
}
