﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligentinfo : MonoBehaviour
{
    public List<string> intelliname = new List<string>();
    public List<string> intellicontent = new List<string>();
    public List<string> intellititle = new List<string>();
    public List<string> intellitext = new List<string>();
    public List<AudioClip> Narration = new List<AudioClip>();

    public List<string> intelliname_E = new List<string>();
    public List<string> intellicontent_E = new List<string>();
    public List<string> intellititle_E = new List<string>();
    public List<string> intellitext_E = new List<string>();
    public List<AudioClip> Narration_E = new List<AudioClip>();

    public List<string> intelliname_C = new List<string>();
    public List<string> intellicontent_C = new List<string>();
    public List<string> intellititle_C = new List<string>();
    public List<string> intellitext_C = new List<string>();
    public List<AudioClip> Narration_C = new List<AudioClip>();

    public List<string> intelliname_J = new List<string>();
    public List<string> intellicontent_J = new List<string>();
    public List<string> intellititle_J = new List<string>();
    public List<string> intellitext_J = new List<string>();
    public List<AudioClip> Narration_J = new List<AudioClip>();


    public List<string> ganzi = new List<string>();
    private void Start()
    {
        intelliname.Add("메인광장");
        intelliname.Add("메인광장");
        intelliname.Add("천우각");
        intelliname.Add("천우각");
        intelliname.Add("청학지");
        intelliname.Add("청학지");
        intelliname.Add("남산국악당");
        intelliname.Add("남산국악당");
        intelliname.Add("이승업가옥");
        intelliname.Add("이승업가옥");
        intelliname.Add("윤씨가옥");
        intelliname.Add("윤씨가옥");
        intelliname.Add("김춘영가옥");
        intelliname.Add("김춘영가옥");
        intelliname.Add("민씨가옥");
        intelliname.Add("민씨가옥");
        intelliname.Add("윤택영재실");
        intelliname.Add("윤택영재실");
        intelliname.Add("전망대");

        intellicontent.Add("인간관계의 지혜");
        intellicontent.Add("인간관계의 지혜");
        intellicontent.Add("인간관계의 지혜");
        intellicontent.Add("인간관계의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("삶의 지혜");
        intellicontent.Add("좋은 벗을 얻는 지혜");
        intellicontent.Add("좋은 벗을 얻는 지혜");

        intellititle.Add("접인춘풍");
        intellititle.Add("교학상장");
        intellititle.Add("선행기언 이후종지");
        intellititle.Add("기신부정 수령부종");
        intellititle.Add("사필귀정");
        intellititle.Add("무괴아심");
        intellititle.Add("심청사달");
        intellititle.Add("공평무사");
        intellititle.Add("비례부동");
        intellititle.Add("일소만사공");
        intellititle.Add("화순제가지본");
        intellititle.Add("부윤옥덕윤신");
        intellititle.Add("백론불여일행");
        intellititle.Add("적선지가 필유여경");
        intellititle.Add("면일시지분 면백일지우");
        intellititle.Add("타산지석");
        intellititle.Add("넓적다리에 살이 찌는 것을 보고 한탄한다");
        intellititle.Add("눌언민행");
        intellititle.Add("예속상교 환난상휼");

        intellitext.Add("사람을 대할 때는 봄바람처럼 부드럽게 하라");
        intellitext.Add("가르치고 배우며 함께 성장한다");
        intellitext.Add("자기가 한 말을 실행하게 되면 남들도 따르게 된다.");
        intellitext.Add("몸가짐 바르지 않으면 비록 호령을 해도 따르지 않는다");
        intellitext.Add("모든 일은 반드시 바른대로 돌아간다");
        intellitext.Add("내 마음에 부끄러움이 없도록 하라");
        intellitext.Add("마음이 맑으면 모든 일이 잘 이루어진다.");
        intellitext.Add("공평하여 사사로움이 없다");
        intellitext.Add("예의에 맞지 않는 것이라면 행동하지 않는다");
        intellitext.Add("한 번 웃어 모든 시름을 날려보낸다.");
        intellitext.Add("화순함이 집안을 가즈런히 하는 근본이다");
        intellitext.Add("부는 집을 풍요롭게 하고 덕은 자신을 풍요롭게 한다");
        intellitext.Add("백 가지 논란은 한 가지 행함과 같지 못하다");
        intellitext.Add("선을 쌓은 집에는 반드시 경사스러움이 있다");
        intellitext.Add("한 때의 분한 마음을 참으면 백일 동안의 근심을 면할 것이다");
        intellitext.Add("쓸모 없는 것이라도 쓰기에 따라 유용한 것이 될 수 있다");
        intellitext.Add("보람 있는 일을 하지 못하고 헛되이 세월만 보내는 것을 한탄함");
        intellitext.Add("말은 조심하고, 행동은 바르게 하는 것");
        intellitext.Add("예절과 풍속에 서로 다니며 어려움에 서로 도와준다");

        intelliname_E.Add("Madang(Yard)");
        intelliname_E.Add("Madang(Yard)");
        intelliname_E.Add("Cheonwu Pavilion");
        intelliname_E.Add("Cheonwu Pavilion");
        intelliname_E.Add("Cheonghakji Pond");
        intelliname_E.Add("Cheonghakji Pond");
        intelliname_E.Add("Seoul Namsan Gukakdang");
        intelliname_E.Add("Seoul Namsan Gukakdang");
        intelliname_E.Add("Carpenter Lee Seung-eop' House in Samgak-dong");
        intelliname_E.Add("Carpenter Lee Seung-eop' House in Samgak-dong");
        intelliname_E.Add("Yun Family's House in Ogin-dong");
        intelliname_E.Add("Yun Family's House in Ogin-dong");
        intelliname_E.Add("General Kim Choon-yeong's House in Samcheong-dong");
        intelliname_E.Add("General Kim Choon-yeong's House in Samcheong-dong");
        intelliname_E.Add("Min Family's House in Gwanhun-dong");
        intelliname_E.Add("Min Family's House in Gwanhun-dong");
        intelliname_E.Add("Yun Taek-yeong's Jaesil in Jegi-dong");
        intelliname_E.Add("Yun Taek-yeong's Jaesil in Jegi-dong");
        intelliname_E.Add("Observatory");

        intelliname_C.Add("庭院");
        intelliname_C.Add("庭院");
        intelliname_C.Add("泉雨阁");
        intelliname_C.Add("泉雨阁");
        intelliname_C.Add("青鹤池");
        intelliname_C.Add("青鹤池");
        intelliname_C.Add("国乐堂(户外庭院)");
        intelliname_C.Add("国乐堂(户外庭院)");
        intelliname_C.Add("三角洞木匠李程业故居");
        intelliname_C.Add("三角洞木匠李程业故居");
        intelliname_C.Add("玉仁洞尹氏故居");
        intelliname_C.Add("玉仁洞尹氏故居");
        intelliname_C.Add("三清洞五卫将金春永故居");
        intelliname_C.Add("三清洞五卫将金春永故居");
        intelliname_C.Add("宽勋洞闵氏故居");
        intelliname_C.Add("宽勋洞闵氏故居");
        intelliname_C.Add("祭基洞海丰府院君尹泽荣斋室");
        intelliname_C.Add("祭基洞海丰府院君尹泽荣斋室");
        intelliname_C.Add("展望台");

        intelliname_J.Add("庭");
        intelliname_J.Add("庭");
        intelliname_J.Add("天羽閣");
        intelliname_J.Add("天羽閣");
        intelliname_J.Add("青学紙");
        intelliname_J.Add("青学紙");
        intelliname_J.Add("国楽堂(屋外の庭)");
        intelliname_J.Add("国楽堂(屋外の庭)");
        intelliname_J.Add("三角洞都片手イ·スンオプ家屋");
        intelliname_J.Add("三角洞都片手イ·スンオプ家屋");
        intelliname_J.Add("指痛惜光阴虚度，思欲有所作为。");
        intelliname_J.Add("指痛惜光阴虚度，思欲有所作为。");
        intelliname_J.Add("三清洞5位長・金春栄家屋");
        intelliname_J.Add("三清洞5位長・金春栄家屋");
        intelliname_J.Add("寛勲洞閔氏の家屋");
        intelliname_J.Add("寛勲洞閔氏の家屋");
        intelliname_J.Add("祭基洞 海豊府院君ユン·テクヨン斎室");
        intelliname_J.Add("祭基洞 海豊府院君ユン·テクヨン斎室");
        intelliname_J.Add("展望台");

        intellicontent_E.Add("The Wisdom of Human Relationships");
        intellicontent_E.Add("The Wisdom of Human Relationships");
        intellicontent_E.Add("The Wisdom of Human Relationships");
        intellicontent_E.Add("The Wisdom of Human Relationships");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom of life");
        intellicontent_E.Add("Wisdom in Finding Good Friends");
        intellicontent_E.Add("Wisdom in Finding Good Friends");

        intellicontent_C.Add("人际关系的智慧");
        intellicontent_C.Add("人际关系的智慧");
        intellicontent_C.Add("人际关系的智慧");
        intellicontent_C.Add("人际关系的智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("人生智慧");
        intellicontent_C.Add("结交良友的智慧");
        intellicontent_C.Add("结交良友的智慧");

        intellicontent_J.Add("人間関係の知恵");
        intellicontent_J.Add("人間関係の知恵");
        intellicontent_J.Add("人間関係の知恵");
        intellicontent_J.Add("人間関係の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("生の知恵");
        intellicontent_J.Add("良き友達を得る知恵");
        intellicontent_J.Add("良き友達を得る知恵");

        intellititle_E.Add("Jeob-Yin-Chun-Pung");
        intellititle_E.Add("Kyo-hak-sang-jang ");
        intellititle_E.Add("Seon-Haeng-Ki-Eon Yi-Hu-Zhong-Ji");
        intellititle_E.Add("Ki-Shin-Bu-Jeong  SuRyeong-Bu-Jong");
        intellititle_E.Add("Sa-Pil-Gui-Jeong");
        intellititle_E.Add("Mu-Kai-A-Sim");
        intellititle_E.Add("Shim-Cheong-Sa-Dal");
        intellititle_E.Add("Kong-Pyeong-Mu-Sa");
        intellititle_E.Add("Bi-Rye-Bu-Dong");
        intellititle_E.Add("Il-So-Man-Sa-Kong");
        intellititle_E.Add("Hwa-sun-Je-gaibon");
        intellititle_E.Add("Bu-Yun-Ok-Deoky-Un-Shin");
        intellititle_E.Add("Paek-Ron-Bul-Ryeo-Il-Haeng ");
        intellititle_E.Add("Jeok-Seon-Ji-Ka Pil-You-Yeo-Kyoung");
        intellititle_E.Add("Myeon-Il-Si-Ji-Bun Myeon-Paek-Il-Ji-Woo");
        intellititle_E.Add("Ta-San-Ji-Seok");
        intellititle_E.Add("He laments when he sees weight gain on his thighs.");
        intellititle_E.Add("Nul-un-min-haeng");
        intellititle_E.Add("Ye-Sok-Sang-Kyo  Hwan-Nan-Sang-Hyul ");

        intellitext_E.Add("When dealing with people, be as gentle as the spring breeze");
        intellitext_E.Add("Teach, Learn, and Grow Together");
        intellitext_E.Add("When you put into practice what you say, others will follow you.");
        intellitext_E.Add("If you don't groom yourself, you won't follow the order, even if you give it a command.");
        intellitext_E.Add("Everything Must Go Right");
        intellitext_E.Add("Let there be no shame in my heart");
        intellitext_E.Add("When the mind is clear, everything goes well.");
        intellitext_E.Add("Fair and without privacy.");
        intellitext_E.Add("Don't act if it's not polite.");
        intellitext_E.Add("He laughs once and blows away all his troubles.");
        intellitext_E.Add("Harmony is the root of keeping a home in harmony");
        intellitext_E.Add("Wealth enriches the house, and virtue enriches itself");
        intellitext_E.Add("A Hundred Controversies Are Not the Same as One Work");
        intellitext_E.Add("The house on which the line is built must have a slope.");
        intellitext_E.Add("If you endure a moment of resentment, you will be spared a hundred days of anxiety");
        intellitext_E.Add("useless things can become useful depending on what you use");
        intellitext_E.Add("Bemoaning the lack of rewarding work and the wasted years");
        intellitext_E.Add("Be careful with what you say, do your actions right");
        intellitext_E.Add("They walk around in etiquette and customs, helping each other in difficulties");

        intellitext_C.Add("对待它人要如春风般和煦。");
        intellitext_C.Add("教与学互相增长。");
        intellitext_C.Add("只有先做后说，才可以取信于人。");
        intellitext_C.Add("如果自身不端正，即使发命令也没有人听从。");
        intellitext_C.Add("不管什么事，最后都要归结到正路上来。");
        intellitext_C.Add("不愧对自己的内心");
        intellitext_C.Add("心如明镜，诸事亨通。");
        intellitext_C.Add("办事公平，没有私心。");
        intellitext_C.Add("不合符礼教的事不做。");
        intellitext_C.Add("一笑解千愁");
        intellitext_C.Add("家庭和睦是治家之本。");
        intellitext_C.Add("富能修饰房屋，得能修养品性。");
        intellitext_C.Add("讨论百次不如行动一次。");
        intellitext_C.Add("修善积德的家庭，必然有更多的吉庆。");
        intellitext_C.Add("容忍一时的气愤就会避免很长时间的忧虑。");
        intellitext_C.Add("能帮助自己改正缺点的人或意见。");
        intellitext_C.Add("指痛惜光阴虚度，思欲有所作为。");
        intellitext_C.Add("指说话谨慎，办事敏捷。");
        intellitext_C.Add("以礼仪和习俗相交，遇到患难彼此互相救助。");

        intellitext_J.Add("人に接するときは春風のように優しくしなさい。");
        intellitext_J.Add("教えて学び、互いに成長する。");
        intellitext_J.Add("自分の言ったことを行えば人は従うようになる。");
        intellitext_J.Add("自分自身が正しくさえあれば、命令などしなくとも人々は行動する。");
        intellitext_J.Add("すべてのことは必ず正しい道理に帰する。");
        intellitext_J.Add("私の心に恥じないようにしなさい。");
        intellitext_J.Add("心が晴れたらすべてがうまくいく。");
        intellitext_J.Add("公平で私事がない。");
        intellitext_J.Add("礼儀正しくないものなら行動しない。");
        intellitext_J.Add("一度笑ってすべての憂いを吹き飛ばす。");
        intellitext_J.Add("和順が家の中を整える根本だ。");
        intellitext_J.Add("富は家を豊かにし、徳は自分を豊かにする。");
        intellitext_J.Add("百回考えても、自分で行動しなければ意味がない。");
        intellitext_J.Add("善行を多く積み重ねた家には、必ず良いことが起こる。");
        intellitext_J.Add("一時の悔しさを堪えれば百日の憂いを免れるだろう。");
        intellitext_J.Add("役に立たないものでも使い方によっては役に立つものになりうる。");
        intellitext_J.Add("やりがいのある仕事が出来ず無駄に歳月を過ごすことを嘆く。");
        intellitext_J.Add("言葉は気をつけ、行動は正しくすること。");
        intellitext_J.Add("礼儀と風俗に通い、困難を助け合う。");

        ganzi.Add("接人春風");
        ganzi.Add("敎學相長");
        ganzi.Add("先行其言 而後從之");
        ganzi.Add("其身不正 雖令不從");
        ganzi.Add("事必歸正");
        ganzi.Add("無愧我心");
        ganzi.Add("心淸事達");
        ganzi.Add("公平無私");
        ganzi.Add("非禮不動");
        ganzi.Add("一笑萬事空");
        ganzi.Add("和順齊家之本");
        ganzi.Add("富潤屋德潤身");
        ganzi.Add("百論不如一行");
        ganzi.Add("積善之家必有餘慶");
        ganzi.Add("忍一時之忿 免百日之憂");
        ganzi.Add("他山之石");
        ganzi.Add("");
        ganzi.Add("訥言敏行");
        ganzi.Add("禮俗相交 患難相恤");
    }
}
