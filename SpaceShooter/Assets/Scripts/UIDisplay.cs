using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("TMPro")]
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();  
    }

    private void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("000000");
    }

}
