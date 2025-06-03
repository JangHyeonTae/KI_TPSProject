using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private MazeCell mazeCellPrefab;

    //크기와 구성
    [SerializeField] private int mazeWidth;
    [SerializeField] private int mazeDepth;
    [SerializeField] private int cellSize;
    private GameObject parentObject;
    private GameObject boxObject;
    //gird cell들을 2차원 배열로 생성
    private MazeCell[,] mazeGrid;

    [SerializeField] private GameObject[] boxPrefab;
    public int boxCount = 10;

    private void Awake()
    {
        parentObject = new GameObject($"{gameObject.name}_Parent");
        boxObject = new GameObject($"{gameObject.name}_Parent");
    }

    //2, 7
    //void 뺴주는 작업
    void Start()
    {
        mazeGrid = new MazeCell[mazeWidth, mazeDepth];

        for (int x = 0; x < mazeWidth; x++)
        {
            for (int z = 0; z < mazeDepth; z++)
            {
                mazeGrid[x,z] = Instantiate(mazeCellPrefab, new Vector3(x,0,z) * cellSize, Quaternion.identity, parentObject.transform);
                
            }
        }
        PlaceRandomBoxes();
        GenerateMaze(null, mazeGrid[0,0]);
    }

    private void PlaceRandomBoxes()
    {
        List<MazeCell> allCells = new List<MazeCell>();
        
        for (int x = 0; x < mazeWidth; x++)
        {
            for (int z = 0; z < mazeDepth; z++)
            {
                allCells.Add(mazeGrid[x, z]);
            }
        }

        // 중복 없이 셔플
        allCells = allCells.OrderBy(_ => Random.value).ToList();

        for (int i = 0; i < Mathf.Min(boxCount, allCells.Count); i++)
        {
            int rand = Random.Range(0, 2);
            Vector3 pos = allCells[i].transform.position;
            switch(rand)
            {
                case 0:
                    Instantiate(boxPrefab[0], pos, Quaternion.identity, boxObject.transform);
                    break;
                case 1:
                    Instantiate(boxPrefab[1], pos, Quaternion.identity, boxObject.transform);
                    break;
                case 2:
                    Instantiate(boxPrefab[2], pos, Quaternion.identity, boxObject.transform);
                    break;
            }
            
        }
    }

    //6
    private void GenerateMaze(MazeCell _previousCell,MazeCell _currentCell)
    {
        _currentCell.Visit();
        ClearWalls(_previousCell,_currentCell);


        #region 8 추가작업?
        MazeCell nextCell;
        do
        {
            nextCell = GetNextUnvisitedCell(_currentCell);

            if (nextCell != null)
            {
                GenerateMaze(_currentCell, nextCell);
            }
        }
        while (nextCell != null);

        #endregion
        //var nextCell = GetNextUnvisitedCell(_currentCell);
        //
        //if (nextCell != null)
        //{
        //    yield return GenerateMaze(_currentCell, nextCell);
        //}
    }

    //5
    private MazeCell GetNextUnvisitedCell(MazeCell _curenntCell)
    {
        var unvisitedCells = GetUnvisitedCells(_curenntCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }


    //3
    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell _currentCell)
    {
        int x = (int)(_currentCell.transform.position.x / cellSize);
        int z = (int)(_currentCell.transform.position.z / cellSize);

        if (x + 1 < mazeWidth)
        {
            MazeCell cellToRight = mazeGrid[x + 1, z];

            if (cellToRight.isVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            MazeCell cellToLeft = mazeGrid[x - 1, z];

            if (cellToLeft.isVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + 1 < mazeDepth)
        {
            MazeCell cellToFront = mazeGrid[x, z + 1];

            if (cellToFront.isVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - 1 >= 0)
        {
            MazeCell cellToBack = mazeGrid[x, z - 1];
            
            if (cellToBack.isVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    //4
    private void ClearWalls(MazeCell _previousCell, MazeCell _currentCell)
    {
        if (_previousCell == null)
        {
            return;
        }

        if (_previousCell.transform.position.x < _currentCell.transform.position.x)
        {
            _previousCell.ClearRightWall();
            _currentCell.ClearLeftWall();
            return;
        }

        if (_previousCell.transform.position.x > _currentCell.transform.position.x)
        {
            _previousCell.ClearLeftWall();
            _currentCell.ClearRightWall();
            return;
        }

        if (_previousCell.transform.position.z < _currentCell.transform.position.z)
        {
            _previousCell.ClearFrontWall();
            _currentCell.ClearBackWall();
            return;
        }

        if (_previousCell.transform.position.z > _currentCell.transform.position.z)
        {
            _previousCell.ClearBackWall();
            _currentCell.ClearFrontWall();
            return;
        }
    }

    void Update()
    {
        
    }
}
