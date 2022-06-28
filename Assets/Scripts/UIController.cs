using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingPopup settingsPopup;
    private int _score;

    void Awake()
    {
      // tells messenger to add this object as listener. Specify the message it listens to and the function it does in response
      Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void OnDestroy()
    {
      Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();
        settingsPopup.Close();
    }

    private void OnEnemyHit()
    {
      _score += 1;
      scoreLabel.text = _score.ToString();
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }

    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
}
