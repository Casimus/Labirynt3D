using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Texture2D map;
    [SerializeField] private ColorToPrefab[] colorMaping;
    [SerializeField] private float offset = 5f;


    private void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0) return;

        foreach (var color in colorMaping)
        {
            if (color.color == pixelColor)
            {
                Instantiate(color.prefab,
                    new Vector3(x, 0, z) * offset,
                    Quaternion.identity,
                    transform);
            }
        }

    }

    public void GenerateLabirynth()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
    }
}
