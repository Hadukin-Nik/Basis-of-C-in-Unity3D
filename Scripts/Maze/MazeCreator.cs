using System;
using UnityEngine;

namespace Maze
{
    public sealed class MazeCreator : MonoBehaviour
    {
        private GameObject[] _objectsOfMaze;
        private int[,] _mazeMap;
        public void createMaze (Vector2 sizeOfMaze)
        {
            DestroyMaze();
            MazeMapCreate();
            MazeMapVisualization();
        }

        private void DestroyMaze()
        {
            for (int i = 0; i < _objectsOfMaze.Length; i++)
            {
                Destroy(_objectsOfMaze[i]);
            }
            Array.Resize(ref _objectsOfMaze, 0);
            _mazeMap = new int[0,0];
        }

        private void MazeMapCreate()
        {

        }

        private void MazeMapVisualization()
        {

        }
    }
}

