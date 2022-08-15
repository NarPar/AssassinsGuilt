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

    private List<GameObject> _characterCards = new List<GameObject>();
    private List<GameObject> _weaponCards = new List<GameObject>();

    public void UpdateDisplay(GameManager gameManager)
    {
        ScoreText.text = "Score: " + gameManager.Score;

        List<Character> characters = gameManager.DrawnCharacters;

        _characterCards.Clear();
        for (int i = 0; i < characters.Count; i++)
        {
            GameObject characterCard = Instantiate(characterCardPrefab);
            characterCard.GetComponent<CharacterCardDisplay>().Init(characters[i]);
        }

        List<WeaponCard> weapons = gameManager.DrawnWeapons;
        _weaponCards.Clear();
        for (int i = 0; i < weapons.Count; i++)
        {
            GameObject weaponCard = Instantiate(weaponCardPrefab);
            weaponCard.GetComponent<WeaponCardDisplay>().Init(weapons[i]);
        }

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
