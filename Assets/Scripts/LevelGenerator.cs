using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Texture2D map;
    [SerializeField] ColorToPrefab[] colorMapping;
    [SerializeField] float offset = 5;
    [SerializeField] Transform parent;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0) { return; }

        foreach (var color in colorMapping)
        {
            if (color.color.Equals(pixelColor))
            {
                Instantiate(color.prefab, new Vector3(x, 0, z) * offset, Quaternion.identity, parent);
            }
        }
    }
}
