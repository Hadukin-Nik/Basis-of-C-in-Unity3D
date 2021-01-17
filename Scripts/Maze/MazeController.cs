using Maze;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    [SerializeField] private bool _shouldIcreateNewMaze = false;
    [SerializeField] private Vector2 _sizeOfMaze = new Vector2(5.0f, 6.0f);

    private MazeCreator _mazeController = new MazeCreator();

    private void FixedUpdate()
    {
        MazeUpdate();
    }
    private void MazeUpdate()
    {
        if (_shouldIcreateNewMaze)
        {
            _mazeController.createMaze(_sizeOfMaze);
            _shouldIcreateNewMaze = false;
        }
    }
}
