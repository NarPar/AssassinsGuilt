using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.google.com/document/d/1R7UUxGDW_HaBHFXyLPjqpqMupcBgtqycbcvRPxr93sA/edit#

public enum GameState { Draw, Action, End }
public enum ActionState { Waiting, Killing }
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

    public int InvestigationsRemaining = 1;
    public WeaponCard selectedWeapon = null;

    private List<Character> _drawnCharacters = new List<Character>();
    private List<WeaponCard> _drawnWeapons = new List<WeaponCard>();

    private GameState _state = GameState.Draw;
    private ActionState _actionState = ActionState.Waiting;
    private int _score = 0;

    private List<string> _availableNames = new List<string>();
    private List<CharacterCard> _availableCharacters = new List<CharacterCard>();
    private List<BackstoryCard> _availableBackstories = new List<BackstoryCard>();
    private List<WeaponCard> _availableWeapons = new List<WeaponCard>();

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;

        for (int i = 0; i < names.Length; i++)
        {
            _availableNames.Add(names[i]);
        }

        for (int i = 0; i < characters.Length; i++)
        {
            _availableCharacters.Add(characters[i]);
        }

        for (int i = 0; i < backstories.Length; i++)
        {
            _availableBackstories.Add(backstories[i]);
        }

        for (int i = 0; i < weapons.Length; i++)
        {
            _availableWeapons.Add(weapons[i]);
        }

        DrawCards();
    }

    private void DrawCards()
    {
        _state = GameState.Draw;

        _drawnCharacters.Clear();
        for (int i = 0; i < charactersPerDraw; i++)
        {
            Character character = new Character();
            character.Name = GetRandomName();
            character.Role = GetRandomRoleCard();
            character.Backstory1 = GetRandomBackstoryCard();
            character.Backstory2 = GetRandomBackstoryCard();
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
        string choice = names[Random.Range(0, names.Length)];
        _availableNames.Remove(choice);
        return choice;
    }

    private CharacterCard GetRandomRoleCard()
    {
        CharacterCard choice = characters[Random.Range(0, characters.Length)];
        _availableCharacters.Remove(choice);
        return choice;
    }

    private BackstoryCard GetRandomBackstoryCard()
    {
        BackstoryCard choice = backstories[Random.Range(0, backstories.Length)];
        _availableBackstories.Remove(choice);
        return choice;
    }

    private WeaponCard GetRandomWeaponCard()
    {
        WeaponCard choice = weapons[Random.Range(0, weapons.Length)];
        _availableWeapons.Remove(choice);
        return choice;
    }

    void ShowCards()
    {
        displayManager.UpdateDisplay(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (_state == GameState.Action)
        {

        }
    }

    private void KillCharacter(Character character)
    {
        Debug.Log("Character " + character.Name + " Killed!");
        _score -= character.Backstory1.moralityCost;
        _score -= character.Backstory2.moralityCost;

        displayManager.UpdateTexts();
    }

    public void HandleCharacterClicked(Character character)
    {
        if (_actionState == ActionState.Waiting && InvestigationsRemaining > 0)
        {
            InvestigationsRemaining -= 1;
            character.BackstoryRevealCount += 1;
            displayManager.UpdateTexts();
        }
        else if(_actionState == ActionState.Killing)
        {
            KillCharacter(character);
        }
    }

    public void HandleWeaponClicked(WeaponCard weaponCard)
    {
        if (_actionState == ActionState.Waiting)
        {
            selectedWeapon = weaponCard;
            _actionState = ActionState.Killing;
        }
        else if (_actionState == ActionState.Killing)
        {
            selectedWeapon = null;
            _actionState = ActionState.Waiting;
        }
    }
}
