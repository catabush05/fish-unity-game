using UnityEngine;
using UnityEngine.U2D;

public class PlantSpawner : MonoBehaviour
{
    [Header("References")]
    public SpriteShapeController floorShape;
    public GameObject[] PlantPrefabs;

    [Header("Settings")]
    public int plantsPerSegment = 3;  // How many plants per edge segment
    public float yOffset = 0f;
    public bool randomize = true;

    void Start()
    {
        SpawnPlants();
    }

    void SpawnPlants()
    {
        if (floorShape == null || PlantPrefabs == null || PlantPrefabs.Length == 0)
        {
            Debug.LogWarning("Missing references in PlantSpawner.");
            return;
        }

        var spline = floorShape.spline;
        int pointCount = spline.GetPointCount();

        // Iterate over each spline segment
        for (int i = 0; i < pointCount - 1; i++)
        {
            Vector3 p0 = spline.GetPosition(i);
            Vector3 p1 = spline.GetPosition((i + 1) % pointCount);

            for (int j = 0; j < plantsPerSegment; j++)
            {
                float t = (float)j / plantsPerSegment;
                Vector3 position = Vector3.Lerp(p0, p1, t);
                position.y += yOffset;

                var prefab = PlantPrefabs[Random.Range(0, PlantPrefabs.Length)];
                var plant = Instantiate(prefab, position, Quaternion.identity, transform);

                if (randomize)
                {
                    // Random scale & slight offset for variation
                    float scale = Random.Range(0.9f, 1.1f);
                    plant.transform.localScale = new Vector3(scale, scale, 1);
                    plant.transform.localPosition += new Vector3(Random.Range(-0.05f, 0.05f), 0, 0);
                }
            }
        }
    }
}
