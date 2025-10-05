using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        int playerIndexLayer = LayerMask.NameToLayer("Player");

        if (layer == playerIndexLayer)
        {
            print("You crashed!");
        }

    }
}
