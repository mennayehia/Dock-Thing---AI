//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Palmmedia.ReportGenerator.Core;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.AI;
//using static UnityEngine.UIElements.UxmlAttributeDescription;

//public class MazeGenerator : MonoBehaviour
//{
//    [SerializeField]private NavMeshSurface m_NavMeshSurface;

//    int[,] mazeArray = new int[,] {
//    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
//    {1,0,0,0,0,0,1,0,1,1,1,0,0,0,1},
//    {1,1,1,1,1,0,1,0,1,0,0,0,1,0,1},
//    {1,0,0,0,1,0,1,0,0,0,1,1,1,0,1},
//    {1,0,1,1,1,0,1,0,1,0,1,0,0,0,1},
//    {1,0,0,0,0,0,1,0,1,1,1,0,1,0,1},
//    {1,1,1,1,1,0,1,0,0,0,0,0,1,0,1},
//    {1,0,0,0,1,0,1,1,1,1,1,1,1,0,1},
//    {1,0,1,1,1,0,0,0,0,0,0,0,0,0,1},
//    {1,0,0,0,1,0,1,1,1,1,1,0,1,0,1},
//    {1,1,1,0,1,0,1,0,0,0,0,0,1,0,1},
//    {1,0,0,0,1,0,1,0,1,1,1,1,1,0,1},
//    {1,0,1,1,1,0,1,0,0,0,0,0,1,0,1},
//    {1,0,0,0,0,0,1,1,1,1,1,0,1,0,1},
//    {1,1,1,1,1,1,1,1,1,1,1,1,1,0,1}


//};

//    private void Start()
//    {
//        GenerateMaze();
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            m_NavMeshSurface.BuildNavMesh();

//        }

//    }

//    void GenerateMaze()
//    {
//        // Loop through the 2D array and create cubes for each element
//        for (int x = 0; x < mazeArray.GetLength(0); x++)
//        {

//            for (int y = 0; y < mazeArray.GetLength(1); y++)
//            {
//                if (mazeArray[x, y] == 1)
//                {
//                    // Obstacle
//                    InstantiateCube(new Vector3(x * 2, 1, y * 2));
//                                   }
          
//            }
//        }
//    }

//    void InstantiateCube(Vector3 position)
//    {
//        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//        cube.transform.position = position;
//        cube.transform.localScale = new Vector3(2, 2, 2);
//        //var obstacle = cube.AddComponent<NavMeshObstacle>();
//        //obstacle.carving = true;

//        //var obstacle = cube.AddComponent<NavMeshModifier>();
//        //obstacle.overrideArea = true;
//        //obstacle.area = 1;

//    }


//}
