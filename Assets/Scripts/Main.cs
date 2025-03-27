using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameScript pigs;
    public Slingshot sh;

    private void Awake()
    {
        pigs = GetComponentInChildren<GameScript>();
        sh = GetComponentInChildren<Slingshot>();
    }

    void Update()
    {
        
    }

    public int Score() {
        return (sh.birds_remaining + 2) * 10000;
    }

    public bool WinCondition() {
        return pigs.Check();
    }

    public bool LooseCondition() {
        return sh.Check() && !WinCondition();
    }
}
