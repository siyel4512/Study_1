using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneratePyramid : MonoBehaviour
{
    private GameObject cube;
    public List<GameObject> cubes;
    private Vector3 spawnPos;

    public float x = 1f;
    public float y = 1f;
    public float z = 1f;

    public int totalFloot;
    private int currentFloot = 0;

    private bool isPick = false;

    public delegate void Generator();
    public Generator generator;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = Vector3.zero;
        cube = Resources.Load<GameObject>("Prefabs/cube");

        generator += ResetState;
        generator += SetCubeSize;
        generator += Generate;
    }

    public void SetCubeSize()
    {
        cube.transform.localScale = new Vector3(x, y, z);
    }

    public void ResetState()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            Destroy(cubes[i]);
        }

        cubes.Clear();
        
        spawnPos = Vector3.zero;
        currentFloot = 0;
        isPick = false;
    }

    public void Generate()
    {
        if (currentFloot >= totalFloot && !isPick)
        {
            isPick = true;
        }
        else if (currentFloot <=0 && isPick)
        {
            return;
        }

        if (!isPick)
        {
            currentFloot++;
        }
        else
        {
            currentFloot--;
        }

        int step = currentFloot;

        for (int i = 0; i < currentFloot; i++)
        {
            spawnPos.x = -((float)(step - x) / 2);

            for (int j = 0; j < step; j++)
            {
                cubes.Add(Instantiate(cube, spawnPos, Quaternion.identity));
                spawnPos.x += x;
            }

            step--;
            spawnPos.y += y;
        }

        spawnPos.z += z;
        spawnPos.y = 0;

        Generate();
    }
}
