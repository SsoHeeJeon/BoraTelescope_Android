using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using hap = HtmlAgilityPack;
using UnityEngine;
using UnityEngine.UI;
using HtmlAgilityPack;
using System.Linq;

public class WebCrolling : MonoBehaviour
{
    [SerializeField]
    Text HomePi;
    [SerializeField]
    Text AwayPi;
    [SerializeField]
    Text TimeText;

    [SerializeField]
    Image HomeImg;
    [SerializeField]
    Image AwayImg;

    [SerializeField]
    Sprite[] LogoImg;

    void Start()
    {
        string url = "https://search.naver.com/search.naver?where=nexearch&sm=top_hty&fbm=1&ie=utf8&query=%EC%9E%A0%EC%8B%A4%EC%95%BC%EA%B5%AC%EC%9E%A5";
        HtmlWeb web = new HtmlWeb();
        web.OverrideEncoding = Encoding.UTF8;
        HtmlDocument htmlDoc = web.Load(url);

        HtmlNode Away = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"_nx_place_additional_info_wrapper\"]/section[1]/div/ul/li[3]/div[2]/div/a[1]");

        HtmlNode home = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"_nx_place_additional_info_wrapper\"]/section[1]/div/ul/li[3]/div[2]/div/a[2]");

        HtmlNode Day = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"_nx_place_additional_info_wrapper\"]/section[1]/div/ul/li[3]/div[1]/span[1]");

        string month = Day.InnerText.Substring(0, 2);
        string Daily = Day.InnerText.Substring(3, 2);

        HtmlNode Time = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"_nx_place_additional_info_wrapper\"]/section[1]/div/ul/li[3]/div[1]/span[2]");
        TimeText.text = Time.InnerText;
        string ChangeAway = "";
        string ChangeHome = "";

        switch (Away.InnerText)
        {
            case "LG":
                ChangeAway = "LG";
                AwayImg.sprite = LogoImg[0];
                break;
            case "SSG":
                ChangeAway = "SSG";
                AwayImg.sprite = LogoImg[1];
                break;
            case "µÎ»ê":
                ChangeAway = "%EB%91%90%EC%82%B0";
                AwayImg.sprite = LogoImg[2];
                break;
            case "·Ôµ¥":
                ChangeAway = "%EB%A1%AF%EB%8D%B0";
                AwayImg.sprite = LogoImg[3];
                break;
            case "NC":
                ChangeAway = "NC";
                AwayImg.sprite = LogoImg[4];
                break;
            case "Å°¿ò":
                ChangeAway = "%ED%82%A4%EC%9B%80";
                AwayImg.sprite = LogoImg[5];
                break;
            case "KT":
                ChangeAway = "KT";
                AwayImg.sprite = LogoImg[6];
                break;
            case "KIA":
                ChangeAway = "KIA";
                AwayImg.sprite = LogoImg[7];
                break;
            case "»ï¼º":
                ChangeAway = "%EC%82%BC%EC%84%B1";
                AwayImg.sprite = LogoImg[8];
                break;
            case "ÇÑÈ­":
                ChangeAway = "%ED%95%9C%ED%99%94";
                AwayImg.sprite = LogoImg[9];
                break;
        }
        AwayImg.SetNativeSize();

        switch (home.InnerText)
        {
            case "LG":
                ChangeHome = "LG";
                HomeImg.sprite = LogoImg[0];
                break;
            case "SSG":
                ChangeAway = "SSG";
                HomeImg.sprite = LogoImg[1];
                break;
            case "µÎ»ê":
                ChangeHome = "%EB%91%90%EC%82%B0";
                HomeImg.sprite = LogoImg[2];
                break;
            case "·Ôµ¥":
                ChangeHome = "%EB%A1%AF%EB%8D%B0";
                HomeImg.sprite = LogoImg[3];
                break;
            case "NC":
                ChangeHome = "NC";
                HomeImg.sprite = LogoImg[4];
                break;
            case "Å°¿ò":
                ChangeHome = "%ED%82%A4%EC%9B%80";
                HomeImg.sprite = LogoImg[5];
                break;
            case "KT":
                ChangeHome = "KT";
                HomeImg.sprite = LogoImg[6];
                break;
            case "KIA":
                ChangeHome = "KIA";
                HomeImg.sprite = LogoImg[7];
                break;
            case "»ï¼º":
                ChangeHome = "%EC%82%BC%EC%84%B1";
                HomeImg.sprite = LogoImg[8];
                break;
            case "ÇÑÈ­":
                ChangeHome = "%ED%95%9C%ED%99%94";
                HomeImg.sprite = LogoImg[9];
                break;
        }
        HomeImg.SetNativeSize();
        string BaseBallurl = "https://search.naver.com/search.naver?where=m&sm=mtb_etc&query=2023%EB%85%84%20" + month + "%EC%9B%94%20" + Daily + "%EC%9D%BC%20" + ChangeAway + "%20" + ChangeHome;
        HtmlWeb BaseBallweb = new HtmlWeb();
        BaseBallweb.OverrideEncoding = Encoding.UTF8;
        HtmlDocument BaseBallhtmlDoc = BaseBallweb.Load(BaseBallurl);
        HtmlNode Awaypitcher = BaseBallhtmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"main_pack\"]/section[1]/div/div[2]/div/div/div[1]/div[1]/p/span/a");
        AwayPi.text = Awaypitcher.InnerText;
        HtmlNode Homepitcher = BaseBallhtmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"main_pack\"]/section[1]/div/div[2]/div/div/div[1]/div[3]/p/span/a");
        HomePi.text = Homepitcher.InnerText;
    }
}
