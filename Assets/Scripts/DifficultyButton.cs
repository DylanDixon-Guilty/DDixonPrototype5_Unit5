using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public GameObject TitleScreen;
    public int Difficulty;

    private Button difficultyButton;
    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficultyButton = GetComponent<Button>();

        difficultyButton.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        gameManager.StartGame(Difficulty);
        TitleScreen.SetActive(false);
    }
}
