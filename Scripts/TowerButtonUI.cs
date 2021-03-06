using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TowerButtonUI : MonoBehaviour
{
    public TowerData tower; 
    public TextMeshProUGUI towerNameText;
    public TextMeshProUGUI towerCostText;
    public Image towerIcon;
    public Button button;

    void onEnable (){
        GameManager.instance.onMoneyChanged.AddListener(OnMoneyChanged);
    }

    void onDisable (){
        GameManager.instance.onMoneyChanged.RemoveListener(OnMoneyChanged);
    }
    void Awake (){
        button = GetComponent<Button>();
    }


    void Start (){
        towerNameText.text = tower.displayName;
        towerCostText.text = $"{tower.cost}";
        towerIcon.sprite = tower.icon;

        OnMoneyChanged();
    }
    public void OnClick (){
       GameManager.instance.towerPlacement.SelectTowerToPlace(tower); 
    }

    void OnMoneyChanged (){
         button.interactable = GameManager.instance.money >= tower.cost;
    }
}
