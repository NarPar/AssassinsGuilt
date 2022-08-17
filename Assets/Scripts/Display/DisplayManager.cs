using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] GameObject characterCardPrefab = null;
    [SerializeField] GameObject weaponCardPrefab = null;

    [SerializeField] TextMeshProUGUI ScoreText = null;
    [SerializeField] Transform characterList = null;
    [SerializeField] Transform weaponList = null;
    [SerializeField] TextMeshProUGUI InvestigationsRemainingText = null;

    private List<GameObject> _characterCards = new List<GameObject>();
    private List<GameObject> _weaponCards = new List<GameObject>();

    private GameManager _gameManager = null;

    public void UpdateDisplay(GameManager gameManager)
    {
        _gameManager = gameManager;
        UpdateTexts();

        // characters

        for (int i = characterList.transform.childCount - 1; i >= 0; i++)
        {
            Destroy(characterList.transform.GetChild(i));
        }

        List<Character> characters = gameManager.DrawnCharacters;

        _characterCards.Clear();
        for (int i = 0; i < characters.Count; i++)
        {
            GameObject characterCard = Instantiate(characterCardPrefab);
            characterCard.GetComponent<CharacterCardDisplay>().Init(characters[i]);
            characterCard.transform.SetParent(characterList, false);
        }

        // weapons

        for (int i = weaponList.transform.childCount - 1; i >= 0; i++)
        {
            Destroy(weaponList.transform.GetChild(i));
        }

        List<WeaponCard> weapons = gameManager.DrawnWeapons;
        _weaponCards.Clear();
        for (int i = 0; i < weapons.Count; i++)
        {
            GameObject weaponCard = Instantiate(weaponCardPrefab);
            weaponCard.GetComponent<WeaponCardDisplay>().Init(weapons[i]);
            weaponCard.transform.SetParent(weaponList, false);
        }

    }

    public void UpdateTexts()
    {
        ScoreText.text = "Score: " + _gameManager.Score;
        InvestigationsRemainingText.text = "Investigations Remaining: " + _gameManager.InvestigationsRemaining;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
