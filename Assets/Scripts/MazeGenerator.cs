using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeGenerator : MonoBehaviour
{
    private const int ROAD = 0;
    private const int WALL = 1;

    [Header("홀수로 입력!")]
    [SerializeField] private int width;
    [SerializeField] private int height;

    private int[,] map;
    public Vector3 startPosition;
    public Vector3 endPosition;

    [SerializeField] private GameObject Walls;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        map = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //시작 위치
                if (x == 1 && y == 0)
                {
                    map[x, y] = ROAD;
                    startPosition = new Vector3(-width + x, 0.5f, -height + y);
                    GameObject player = Managers.Resource.Instantiate("Player");
                    player.transform.position = startPosition;
                }
                //출구 위치
                else if (x == width - 2 && y == height - 1)
                {
                    map[x, y] = ROAD;
                    endPosition = new Vector3(-width + x, 0.5f, -height + y);
                }
                else if (x == 0 || x == width - 1 || y == 0 || y == height - 1) map[x, y] = WALL; //가장자리 벽
                else if (x % 2 == 0 || y % 2 == 0) map[x, y] = WALL; //짝수 칸 벽
                else map[x, y] = ROAD; //나머지 칸은 길
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2Int pos;
                if (x % 2 == 0 || y % 2 == 0) continue;
                if (x == width - 2 && y == height - 2) continue;
                //오른쪽 끝에 닿으면 길 생성 방향을 위로 설정
                if (x == width - 2)
                {
                    pos = new Vector2Int(x, y + 1);
                }
                //위쪽 끝에 닿으면 길 생성 방향을 오른쪽으로 설정
                else if (y == height - 2)
                {
                    pos = new Vector2Int(x + 1, y);
                }
                //랜덤으로 방향 지정 (위쪽, 오른쪽)
                else if (Random.Range(0, 2) == 0)
                {
                    pos = new Vector2Int(x + 1, y);
                }
                else
                {
                    pos = new Vector2Int(x, y + 1);
                }
                map[pos.x, pos.y] = ROAD; //맵 데이터에 값 저장
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x,y] == WALL)
                {
                    OnDrawWall(x, y);
                }
            }
        }
    }

    private void OnDrawWall(int x, int y)
    {
        Vector3 pos = new Vector3(-width + x, 0.5f, -height + y);
        GameObject wall = Managers.Resource.Instantiate("Wall", Walls.transform);
        wall.transform.position = pos;
    }
}
