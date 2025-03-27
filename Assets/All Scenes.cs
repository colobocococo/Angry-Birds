using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class AllScenes : MonoBehaviour
{

    
    public Main main;
    private TextMeshProUGUI text;

    private void Awake()
    {
        main = GetComponentInChildren<Main>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    GameObject scene1, scene2, scene3;
    void Start()
    {
        scene1 = GameObject.Find("Main Scene");
        scene2 = GameObject.Find("Win Scene");
        scene3 = GameObject.Find("Lose Scene");

        scene1.SetActive(true);
        scene2.SetActive(false);
        scene3.SetActive(false);
    }

    void Update()
    {
        if (main.WinCondition()) {
            text.text = "Score " + main.Score();
            text.color = Color.green;

            scene1.SetActive(false);
            scene2.SetActive(true);
        }

        if (main.LooseCondition()) {
            scene1.SetActive(false);
            scene3.SetActive(true);
        }
    }
}
