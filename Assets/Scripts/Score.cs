using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        scoreText.text = $"Vacuums Filled: {gameManager.roundsWon}";
    }
}
