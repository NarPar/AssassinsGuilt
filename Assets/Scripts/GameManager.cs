using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.google.com/document/d/1R7UUxGDW_HaBHFXyLPjqpqMupcBgtqycbcvRPxr93sA/edit#

public enum GameState { Draw, Action, End }
public class GameManager : MonoBehaviour
{
    [SerializeField] CharacterCard[] characters = null;
    [SerializeField] BackstoryCard[] backstories = null;
    [SerializeField] WeaponCard[] weapons = null;
    [SerializeField] string[] names = null;

    [SerializeField] int charactersPerDraw = 2;
    [SerializeField] int weaponsPerDraw = 2;

    [SerializeField] DisplayManager displayManager = null;

    public int Score { get { return _score; } }
    public List<Character> DrawnCharacters { get { return _drawnCharacters; } }
    public List<WeaponCard> DrawnWeapons { get { return _drawnWeapons; } }

    private List<Character> _drawnCharacters = new List<Character>();
    private List<WeaponCard> _drawnWeapons = new List<WeaponCard>();

    private GameState _state = GameState.Draw;
    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _state = GameState.Draw;
    }

    private void DrawCards()
    {
        // todo
        _drawnCharacters.Clear();
        for (int i = 0; i < charactersPerDraw; i++)
        {
            Character character = new Character();
            character.Name = GetRandomName();
            character.Role = GetRandomRoleCard();
            character.Backstory = GetRandomBackstoryCard();
            _drawnCharacters.Add(character);
        }

        _drawnWeapons.Clear();
        for (int i = 0; i < weaponsPerDraw; i++)
        {
            _drawnWeapons.Add(GetRandomWeaponCard());
        }

        ShowCards();

        _state = GameState.Action;
    }

    private string GetRandomName()
    {
        return names[Random.Range(0, names.Length)];
    }

    private CharacterCard GetRandomRoleCard()
    {
        return characters[Random.Range(0, characters.Length)];
    }

    private BackstoryCard GetRandomBackstoryCard()
    {
        return backstories[Random.Range(0, backstories.Length)];
    }

    private WeaponCard GetRandomWeaponCard()
    {
        return weapons[Random.Range(0, weapons.Length)];
    }

    void ShowCards()
    {
        //todo
        displayManager.UpdateDisplay(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (_state == GameState.Action)
        {

        }
    }
}
