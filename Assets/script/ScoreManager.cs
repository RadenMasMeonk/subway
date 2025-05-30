using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int score = 0;
    private int highScore = 0;

    void Start()
    {
        // Ambil high score yang sudah disimpan
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;

        // Update high score jika perlu
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Simpan ke disk
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
    }

    // Reset score (opsional)
    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }
}