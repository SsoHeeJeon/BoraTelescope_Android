using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategorySetting : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField]
    RectTransform Total;
    [SerializeField]
    RectTransform Eco;
    [SerializeField]
    RectTransform Building;

    [SerializeField]
    RectTransform Content;
    void Update()
    {
        switch(GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                Total.anchoredPosition = new Vector2(7.5f, Total.anchoredPosition.y);
                Eco.anchoredPosition = new Vector2(99.4f, Eco.anchoredPosition.y);
                Building.anchoredPosition = new Vector2(225.6f, Building.anchoredPosition.y);
                Content.sizeDelta = new Vector2(370, Content.sizeDelta.y);
                break;
            case GameManager.LangState.English:
                Total.anchoredPosition = new Vector2(7.5f, Total.anchoredPosition.y);
                Eco.anchoredPosition = new Vector2(99.4f, Eco.anchoredPosition.y);
                Building.anchoredPosition = new Vector2(280f, Building.anchoredPosition.y);
                Content.sizeDelta = new Vector2(450, Content.sizeDelta.y);
                break;
            case GameManager.LangState.Chienses:
                Total.anchoredPosition = new Vector2(7.5f, Total.anchoredPosition.y);
                Eco.anchoredPosition = new Vector2(99.4f, Eco.anchoredPosition.y);
                Building.anchoredPosition = new Vector2(240f, Building.anchoredPosition.y);
                Content.sizeDelta = new Vector2(400, Content.sizeDelta.y);
                break;
            case GameManager.LangState.Japan:
                Total.anchoredPosition = new Vector2(7.5f, Total.anchoredPosition.y);
                Eco.anchoredPosition = new Vector2(99.4f, Eco.anchoredPosition.y);
                Building.anchoredPosition = new Vector2(240f, Building.anchoredPosition.y);
                Content.sizeDelta = new Vector2(400, Content.sizeDelta.y);
                break;
        }
    }
}
