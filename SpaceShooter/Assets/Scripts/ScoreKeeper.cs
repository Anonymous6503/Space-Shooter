using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentScore()
    {
        return score;
    }

    public void GetNewScore(int value)
    {
        score += value;
        Mathf.Clamp(score,0,int.MaxValue);
    }

    public void resetScore()
    {
        score = 0;
    }
}
