using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Texture2D map;
    [SerializeField] private ColorToPrefab[] colorsToPrefab;
    [SerializeField] private float offset = 5f;


    private void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0) return;


        foreach (var color in colorsToPrefab)
        {
            if (color.Color == pixelColor)
            {
                Instantiate(color.Prefab, new Vector3(x, 0, z) * offset , 
                    Quaternion.identity, transform) ;
            }
        }

    }

    public void GenerateLabirynth()
    {
        for (int i = 0; i < map.width; i++)
        {
            for (int j= 0; j < map.height; j++)
            {
                GenerateTile(i, j);
            }
        }
    }


}
