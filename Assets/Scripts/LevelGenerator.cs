using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Texture2D map;
    [SerializeField] private ColorToPrefab[] colorMaping;
    [SerializeField] private float offset = 5f;
    [SerializeField] private Material[] wallMaterials;


    private void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0) return;

        foreach (var color in colorMaping)
        {
            if (color.color == pixelColor)
            {
                var newObject = Instantiate(color.prefab, new Vector3(x, 0, z) * offset,
                    Quaternion.identity,transform);

                if (newObject.tag == "Wall")
                {
                    var wallMaterial = Random.Range(0, wallMaterials.Length);

                    newObject.GetComponentInChildren<Renderer>().material =
                        wallMaterials[wallMaterial];
                }
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
