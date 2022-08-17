using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponCardDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText = null;
    [SerializeField] TextMeshProUGUI descriptionText = null;

    private WeaponCard _weaponCard = null;
    private GameManager _gameManager = null;
    private Image _image = null;

    private Color _defaultColor;

    // Start is called before the first frame update
    void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _image = GetComponent<Image>();

        _defaultColor = _image.color;
    }

    public void Init(WeaponCard weapon)
    {
        _weaponCard = weapon;

        UpdateVisuals();
    }

    public void Clicked()
    {
        Debug.Log("Weapon Card " + _weaponCard.name + " Clicked!");
        _gameManager.HandleWeaponClicked(_weaponCard);
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (_gameManager.selectedWeapon != null && _gameManager.selectedWeapon.name == _weaponCard.name)
        {
            Debug.Log("Weapon Selected! Is Red!");
            _image.color = Color.red;
        }
        else
        {
            if (_gameManager.selectedWeapon == null) Debug.Log("Selected weapon = null!");
            else Debug.Log("Selected weapon = " + _gameManager.selectedWeapon.name);

            _image.color = _defaultColor;
        }
        
        nameText.text = _weaponCard.name;
        descriptionText.text = "Time Cost: " + _weaponCard.timeCost + " Kill Chance: " + _weaponCard.chanceToKill + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
