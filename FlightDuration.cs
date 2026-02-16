using UnityEngine;
using TMPro;

// Houdt bij hoeveel flight time je nog hebt
public class FlightDuration : MonoBehaviour
{
    public static FlightDuration instance;

    [SerializeField] private float startTime = 5f; // begin tijd
    [SerializeField] private TextMeshProUGUI timeText; // optioneel UI

    private float currentTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentTime = startTime;
        UpdateUI();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            GameManager.instance.GameOver();
        }

        UpdateUI();
    }

    // dit wordt aangeroepen bij +1 punt
    public void AddTime(float amount)
    {
        currentTime += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (timeText != null)
            timeText.text = "Time: " + currentTime.ToString("0.0");
    }
}