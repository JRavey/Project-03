using UnityEngine;
using System;

public class GameScore : MonoBehaviour
{
    public static event Action<int> OnScored;

    private int _score = 0;

    public int Score => _score;

    

    public void AddScore(int amount)
    {
        _score += amount;

        OnScored?.Invoke(_score);
    }
}
