using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    bool isFollowing = true;

    void Update()
    {

        if (!isFollowing) return;
        // Apply movement and rotation (without deltaTime for now)
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }

    public void StopFollowing()
    {
        isFollowing = false;
    }
}
