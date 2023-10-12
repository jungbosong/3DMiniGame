using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeGenerator : MonoBehaviour
{
    private const int ROAD = 0;
    private const int WALL = 1;

    [Header("Ȧ���� �Է�!")]
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
                //���� ��ġ
                if (x == 1 && y == 0)
                {
                    map[x, y] = ROAD;
                    startPosition = new Vector3(-width + x, 0.5f, -height + y);
                    GameObject player = Managers.Resource.Instantiate("Player");
                    player.transform.position = startPosition;
                }
                //�ⱸ ��ġ
                else if (x == width - 2 && y == height - 1)
                {
                    map[x, y] = ROAD;
                    endPosition = new Vector3(-width + x, 0.5f, -height + y);
                }
                else if (x == 0 || x == width - 1 || y == 0 || y == height - 1) map[x, y] = WALL; //�����ڸ� ��
                else if (x % 2 == 0 || y % 2 == 0) map[x, y] = WALL; //¦�� ĭ ��
                else map[x, y] = ROAD; //������ ĭ�� ��
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2Int pos;
                if (x % 2 == 0 || y % 2 == 0) continue;
                if (x == width - 2 && y == height - 2) continue;
                //������ ���� ������ �� ���� ������ ���� ����
                if (x == width - 2)
                {
                    pos = new Vector2Int(x, y + 1);
                }
                //���� ���� ������ �� ���� ������ ���������� ����
                else if (y == height - 2)
                {
                    pos = new Vector2Int(x + 1, y);
                }
                //�������� ���� ���� (����, ������)
                else if (Random.Range(0, 2) == 0)
                {
                    pos = new Vector2Int(x + 1, y);
                }
                else
                {
                    pos = new Vector2Int(x, y + 1);
                }
                map[pos.x, pos.y] = ROAD; //�� �����Ϳ� �� ����
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
