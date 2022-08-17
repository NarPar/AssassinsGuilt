using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterCardDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText = null;
    [SerializeField] TextMeshProUGUI descriptionText = null;

    private Character _character = null;
    private GameManager _gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void Init(Character character)
    {
        _character = character;

        UpdateText();
    }

    public void Clicked()
    {
        Debug.Log("Character Card " + _character.Name + " Clicked! Revealing Backstory...");
        _gameManager.HandleCharacterClicked(_character);
        UpdateText();
    }

    private void UpdateText()
    {
        nameText.text = _character.Name;
        descriptionText.text = _character.Role.name;
        if (_character.BackstoryRevealCount > 0) descriptionText.text += " " + _character.Backstory1.name;
        if (_character.BackstoryRevealCount > 1) descriptionText.text += " " + _character.Backstory2.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
