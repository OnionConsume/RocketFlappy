using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score = 0;

    private void Awake()
    {
        // simpele singleton zodat we overal Score.instance kunnen gebruiken
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // dubbele score objecten weg
        }
    }

    private void Start()
    {
        // zet begin score
        _currentScoreText.text = _score.ToString();

        // laad highscore uit playerprefs
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // dit wordt aangeroepen als player door pipes gaat
    public void UpdateScore()
    {
        _score++; // score +1
        _currentScoreText.text = _score.ToString();

        // check of nieuwe highscore
        if (_score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            PlayerPrefs.Save(); // opslaan
            _highScoreText.text = _score.ToString();
        }
    }
}