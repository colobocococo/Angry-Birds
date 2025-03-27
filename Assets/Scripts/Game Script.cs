using UnityEngine;

public class GameScript : MonoBehaviour
{
    public int pigs_remaining;
    void Start()
    {
        pigs_remaining = transform.childCount;
    }

    void Update()
    {
        pigs_remaining = transform.childCount;
    }

    public bool Check() {
        return pigs_remaining == 0;
    }
}
