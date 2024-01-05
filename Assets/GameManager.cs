using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Gold = 100;
    public TextMeshProUGUI GoldDisplay;
    public GameObject planet;

    private GameStates _currentState = GameStates.Default;
    public enum GameStates
    {
        Default,
        PlacingObject
    }

    public static GameManager Instance {
        get;
        private set;
    }

    public GameObject Planet { get => planet; set => planet = value; }
    public GameStates CurrentState { get => _currentState;}

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    private void Start()
    {
        UpdateGoldDisplay(Gold);
    }

    public void UpdateGoldDisplay(int GoldValue)
    {
        GoldDisplay.text = "" + GoldValue;
    }

    public void UpdateGold(int GoldChange)
    {
        Gold += GoldChange;
        UpdateGoldDisplay(Gold);
        Debug.Log(GoldChange);
    }

    public void UpdateState(GameStates stateToChengeTo)
    {
        _currentState = stateToChengeTo;
    }
}
