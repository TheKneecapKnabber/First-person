using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    [SerializeField] private Texture2D _mapTexture;
    [SerializeField] private GameObject _cube;
    [SerializeField] private Color _color;

    // Start is called before the first frame update
    void Start()
    {
        ReadMap();
    }

    private void ReadMap()
    {
        int xSize = _mapTexture.width;
        int ySize = _mapTexture.height;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if(_mapTexture.GetPixel(x,y) == _color)
                {
                    Instantiate(_cube, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }
}
