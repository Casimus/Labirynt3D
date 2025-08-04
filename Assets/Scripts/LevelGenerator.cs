using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Texture2D map;
    [SerializeField] ColorToPrefab[] colorMapping;
    [SerializeField] float offset = 5;
    [SerializeField] Transform parent;
    [SerializeField] Material[] materials;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (var color in colorMapping)
        {
            if (color.color.Equals(pixelColor))
            {
                Instantiate(color.prefab, new Vector3(x, 0, z) * offset, Quaternion.identity, parent);
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

    public void ColorTheChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Wall")
            {
                if (Random.Range(1, 100) % 3 == 0)
                {
                    child.gameObject.GetComponentInChildren<Renderer>().material = materials[0];
                }
                else
                {
                    child.gameObject.GetComponentInChildren<Renderer>().material = materials[1];
                }
            }

            if (child.childCount > 0)
            {
                foreach (Transform grandchild in child.transform)
                {
                    if (grandchild.tag == "Wall")
                    {
                        if (Random.Range(1, 100) % 3 == 0)
                        {
                            grandchild.gameObject.GetComponentInChildren<Renderer>().material =
                                materials[0];
                        }
                        else
                        {
                            grandchild.gameObject.GetComponentInChildren<Renderer>().material =
                                materials[1];
                        }
                    }
                }
            }
        }
    }
}