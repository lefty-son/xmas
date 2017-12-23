using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizer : MonoBehaviour {
    public static Localizer instance;

    #region UPGRADES

    private readonly string upgrade_santa = "upgrade_santa";
    private readonly string upgrade_convey = "upgrade_convey";
    private readonly string sled_max = "sled_max";
    private readonly string sled_speed = "sled_speed";

    private readonly string get_twice = "get_twice";
    private readonly string get_just = "get_just";

    private readonly string free_heart = "free_heart";

    private readonly string tutorual = "tutorial";
    private readonly string welcome = "welcome";

    #endregion

    #region NAMES

    private readonly string doggy_name = "doggy_name";
    private readonly string rubber_duck_name = "rubber_duck_name";
	private readonly string teddy_bear_name = "teddy_bear_name";
	private readonly string snow_man_name = "snow_man_name";
    private readonly string beluga_whale_name= "beluga_whale_name";
    private readonly string car_name= "car_name";
    private readonly string cheetah_name= "cheetah_name";
    private readonly string frog_name= "frog_name";
    private readonly string giraffe_name= "giraffe_name";
    private readonly string great_auk_name= "great_auk_name";
    private readonly string lions_name= "lions_name";
    private readonly string mammoth_name= "mammoth_name";
    private readonly string puffin_name= "puffin_name";
    private readonly string ratel_name= "ratel_name";
    private readonly string sea_mink_name= "sea_mink_name";


    #endregion


    private readonly string good1 = "good1";
    private readonly string good2 = "good2";
    private readonly string normal1 = "normal1";
    private readonly string normal2 = "normal2";
    private readonly string bad1 = "bad1";
    private readonly string bad2 = "bad2";

    private Dictionary<string, string> dict;

    private void Awake()
    {
        if (instance == null) instance = this;
        Init();
    }

    public void Init(){
        dict = new Dictionary<string, string>();
        dict.Clear();
        FillDictionary();
    }

    private void FillDictionary(){
        var lang = PrefManager.instance.GetLanguage();

        // EN
        if(lang == 0){
            dict.Add(good1, "Thank you for your last gift.\nThis proved to friends that Santa Claus was there.\n\nMerry Christmas.");
            dict.Add(good2, "Are you really Santa?\n\nI watched you go out to my window last night.\n\nIt is an honor to meet you.\nAlso, I received a gift well.\n\nMerry Christmas.");
            dict.Add(normal1, "To Santa Claus\n\nThe gift I sent was slightly damaged, but...I like it.\nPlease pay more attention next time.\n\nMerry Christmas.");
            dict.Add(normal2, "Hello Santa Claus.\n\nLast year was a bigger doll... \nThis year is too small, is not it ?\n\nThanks anyway.Merry Christmas.");
            dict.Add(bad1, "The gift you sent is a mess.\n\nThe contents are completely damaged.\nI will not believe Santa Claus now.");
            dict.Add(bad2, "I am upset with you.\n\nWhy did you give my friend a better gift ?\n\nWorst Christmas.");

            dict.Add(upgrade_santa, "Speed of Gift Packing");
            dict.Add(upgrade_convey, "Speed of conveyor belt");
            dict.Add(sled_max, "Sledging capacity");
            dict.Add(sled_speed, "Sleighing speed");

            dict.Add(doggy_name, "Doggy");
            dict.Add(rubber_duck_name, "Rubber duck");
            dict.Add(teddy_bear_name, "Teddy bear");
            dict.Add(snow_man_name, "Snow man");
            dict.Add(beluga_whale_name, "Dolphin");
            dict.Add(car_name, "Car");
            dict.Add(cheetah_name, "Cheetah");
            dict.Add(frog_name, "Toad");
            dict.Add(giraffe_name, "Giraffe");
            dict.Add(great_auk_name, "Great auk");
            dict.Add(lions_name, "Lion");
            dict.Add(mammoth_name, "Mammoth");
            dict.Add(puffin_name, "Puffin");
            dict.Add(ratel_name, "Badger");
            dict.Add(sea_mink_name, "Mink");

            dict.Add(get_twice, "Get double!");
            dict.Add(get_just, "No thanks.");

            dict.Add(free_heart, "Free Heart!");

            dict.Add(tutorual, "You've just earned some hearts!\n\nNow you can unlock a new gift on shop!");
            dict.Add(welcome, "Hello Santa Claus!\n\nFrom now on, we need to send gifts to children all over the world.\n\nTouch the screen to wrap the gift.");


        }
        // KO
        else if(lang == 1){

            dict.Add(good1, "지난번 보내주신 선물은 잘 받았습니다.\n덕분에 산타클로스가 존재한다는 것을 친구들에게 증명하였습니다.\n\n메리 크리스마스.");
            dict.Add(good2, "당신은 정말 산타클로스인가요?\n지난 밤 제 방 창문으로 나가는 모습을 보았습니다.\n\n당신을 만나서 영광입니다.\n선물 잘 받았습니다.\n\n메리 크리스마스.");
            dict.Add(normal1, "산타클로스에게\n\n보내주신 선물이 약간 손상되어 있었지만...마음에 듭니다.\n다음에는 조금 더 주의해주세요.\n\n메리 크리스마스.");
            dict.Add(normal2, "안녕 산타클로스.\n\n작년에는 더 큰 인형이었는데...\n올해는 너무 작잖아 ?\n\n그래도 고마워.메리 크리스마스.");
            dict.Add(bad1, "당신이 보내준 선물은 엉망입니다.\n\n내용물이 완전히 손상되었습니다.\n이제 산타클로스는 믿지 않을 겁니다.");
            dict.Add(bad2, "저는 당신에게 화났습니다.\n\n왜 제 친구에게 더 좋은 선물을 줬습니까 ?\n최악의 크리스마스.");

            dict.Add(upgrade_santa, "선물 포장 속도");
            dict.Add(upgrade_convey, "컨베이어 벨트 속도");
            dict.Add(sled_max, "썰매 용량");
            dict.Add(sled_speed, "썰매 배달 속도");

            dict.Add(doggy_name, "강아지");
            dict.Add(rubber_duck_name, "고무 오리");
            dict.Add(teddy_bear_name, "곰인형");
            dict.Add(snow_man_name, "눈사람");
            dict.Add(beluga_whale_name, "돌고래");
            dict.Add(car_name, "자동차");
            dict.Add(cheetah_name, "치타");
            dict.Add(frog_name, "두꺼비");
            dict.Add(giraffe_name, "기린");
            dict.Add(great_auk_name, "바다쇠오리");
            dict.Add(lions_name, "사자");
            dict.Add(mammoth_name, "매머드");
            dict.Add(puffin_name, "바다오리");
            dict.Add(ratel_name, "오소리");
            dict.Add(sea_mink_name, "밍크");

            dict.Add(get_twice, "두 배로 받기!");
            dict.Add(get_just, "그냥 받기.");

            dict.Add(free_heart, "무료 하트!");

            dict.Add(tutorual, "당신은 방금 하트를 얻었습니다!\n\n이제 상점에서 새로운 선물을 열 수 있습니다!");
            dict.Add(welcome, "안녕 산타클로스!\n\n지금부터 전세계에 있는 어린이들에게 선물을 보내야합니다.\n\n화면을 터치하여 선물을 포장하세요.");
        }
        // CN
        else if(lang == 2){
            dict.Add(good1, "谢谢你最后的礼物。\n这向朋友证明，圣诞老人在那里。\n\n圣诞节快乐。");
            dict.Add(good2, "你真的是圣诞老人吗？\n\n我昨天晚上看着你走到我的窗前。\n\n很高兴见到你。\n另外，我收到了一份礼物。\n\n圣诞节快乐。");
            dict.Add(normal1, "给圣诞老人\n\n我送的礼物有点受损，但是...我喜欢。\n下次请多加注意。\n\n圣诞节快乐。");
            dict.Add(normal2, "你好圣诞老人\n\n去年是一个更大的娃娃...\n今年太小了，不是吗？\n\n不管怎么说，还是要谢谢你。 圣诞节快乐。");
            dict.Add(bad1, "你送的礼物是一团糟。\n\n内容完全损坏。\n我现在不会相信圣诞老人。");
            dict.Add(bad2, "我很生气。\n\n你为什么给我的朋友一个更好的礼物？\n\n最坏的圣诞节。");

            dict.Add(upgrade_santa, "礼品包装速度");
            dict.Add(upgrade_convey, "传送带速度");
            dict.Add(sled_max, "雪橇容量");
            dict.Add(sled_speed, "雪橇递送速度");

            dict.Add(doggy_name, "小狗");
            dict.Add(rubber_duck_name, "橡皮鸭");
            dict.Add(teddy_bear_name, "泰迪熊");
            dict.Add(snow_man_name, "雪人");
            dict.Add(beluga_whale_name, "海豚");
            dict.Add(car_name, "汽车");
            dict.Add(cheetah_name, "猎豹");
            dict.Add(frog_name, "蟾蜍");
            dict.Add(giraffe_name, "长颈鹿");
            dict.Add(great_auk_name, "大海雀");
            dict.Add(lions_name, "狮");
            dict.Add(mammoth_name, "大型");
            dict.Add(puffin_name, "海鸭");
            dict.Add(ratel_name, "獾");
            dict.Add(sea_mink_name, "貂皮");

            dict.Add(get_twice, "得到双倍！");
            dict.Add(get_just, "不用了，谢谢。");

            dict.Add(free_heart, "免费的心！");

            dict.Add(tutorual, "你刚刚赢得一些心！\n\n现在你可以在店里解锁一件新的礼物！");
            dict.Add(welcome, "圣诞老人你好！\n\n从现在开始，我们需要送礼物给世界各地的孩子。\n\n触摸屏幕以包裹礼物。");
        }
        // JP
        else if (lang == 3)
        {
            dict.Add(good1, "あなたの最後の贈り物をありがとう。\nこれは、サンタクロースがそこにいることを友人に証明しました。\n\nメリークリスマス。");
             dict.Add(good2, "あなたは本当にサンタですか？\n\n私はあなたが昨晩私の窓に出かけるのを見ました。\n\nあなたに会うのは光栄です。\nまた、私はよく贈り物を受けました。\n\nメリークリスマス。");
              dict.Add(normal1, "サンタクロースに\n\n私が送った贈り物は少し傷ついていましたが...私はそれが好きです。\n次回より注意を払ってください。\n\nメリークリスマス。");
           dict.Add(normal2, "こんにちはサンタクロース。\n\n去年はもっと大きな人形だった...\n今年は小さすぎますね。\n\nとにかくありがとう。 メリークリスマス。");
        dict.Add(bad1, "あなたが送った贈り物は混乱しています。\n\n内容物が完全に損傷しています。\n私は今、サンタクロースを信じていません。");
                 dict.Add(bad2, "私はあなたに怒っている。\n\nなぜあなたは私の友人により良い贈り物を与えましたか？\n\n最悪のクリスマス。");

            dict.Add(upgrade_santa, "贈り物の包装速度");
            dict.Add(upgrade_convey, "コンベアベルト速度");
            dict.Add(sled_max, "プレゼント積載量");
            dict.Add(sled_speed, "そりの送信速度");

            dict.Add(doggy_name, "犬");
            dict.Add(rubber_duck_name, "ラバー・ダック");
            dict.Add(teddy_bear_name, "テディベア");
            dict.Add(snow_man_name, "雪だるま");
            dict.Add(beluga_whale_name, "イルカ");
            dict.Add(car_name, "自動車");
            dict.Add(cheetah_name, "チーター");
            dict.Add(frog_name, "蟾蜍");
            dict.Add(giraffe_name, "キリン");
            dict.Add(great_auk_name, "オオウミガラス");
            dict.Add(lions_name, "獅子");
            dict.Add(mammoth_name, "マンモス");
            dict.Add(puffin_name, "海カモ");
            dict.Add(ratel_name, "アナグマ");
            dict.Add(sea_mink_name, "ミンク");

            dict.Add(get_twice, "ダブルを得る！");
            dict.Add(get_just, "いいえ結構です。");

            dict.Add(free_heart, "無料ハート！");

            dict.Add(tutorual, "あなたはちょうどいくつかの心を得た！\n\n今、あなたは店で新しい贈り物を開くことができます！");
            dict.Add(welcome, "こんにちはサンタクロース！\n\n今から世界中の子供たちにプレゼントを送信します。\n\n画面をタッチして贈り物を包装します。");
        }
        else if(lang == 4)
        {
            dict.Add(good1, "Kiitos viimeisestä lahjastasi.\nTämä osoittautui ystäville, että Joulupukki oli siellä.\n\nHyvää joulua.");
            dict.Add(good2, "Oletko todella Santa?\n\nKatselin sinua menemään ikkunaan viime yönä.\nOn kunnia tavata sinut.\nSain myös lahjan hyvin.\n\nHyvää joulua.");
            dict.Add(normal1, "Joulupukkiin\n\nLähettämä lahja oli hieman vaurioitunut, mutta...Pidän siitä.\nKiinnittäkää enemmän huomiota ensi kerralla.\n\nHyvää joulua.");
            dict.Add(normal2, "Hei Joulupukki.\n\nViime vuonna oli isompi nukke...\nTänä vuonna on liian pieni, eikö olekin ?\n\nKiitos kuitenkin.Hyvää joulua.");
            dict.Add(bad1, "Lähettämäsi lahja on sotku.\n\nSisältö on täysin vaurioitunut.\nEn usko Joulupukkia nyt.");
            dict.Add(bad2, "Olen järkyttynyt kanssasi.\n\nMiksi annoit ystävälleni paremman lahjan ?\n\nHuonoin joulu.");

            dict.Add(upgrade_santa, "Lahjapakkauksen nopeus");
            dict.Add(upgrade_convey, "Kuljetushihnan nopeus");
            dict.Add(sled_max, "Kelkkakapasiteetti");
            dict.Add(sled_speed, "Rullausnopeus");

            dict.Add(doggy_name, "Koira");
            dict.Add(rubber_duck_name, "Kumisate");
            dict.Add(teddy_bear_name, "Nalle");
            dict.Add(snow_man_name, "Snow mies");
            dict.Add(beluga_whale_name, "Delfiini");
            dict.Add(car_name, "Auto");
            dict.Add(cheetah_name, "Gepardi");
            dict.Add(frog_name, "Rupikonna");
            dict.Add(giraffe_name, "Kirahvi");
            dict.Add(great_auk_name, "Suuri auk");
            dict.Add(lions_name, "Leijona");
            dict.Add(mammoth_name, "mammutti");
            dict.Add(puffin_name, "Lunni");
            dict.Add(ratel_name, "Mäyrä");
            dict.Add(sea_mink_name, "Minkki");

            dict.Add(get_twice, "Hanki kaksinkertainen!");
            dict.Add(get_just, "Ei kiitos.");

            dict.Add(free_heart, "Vapaa sydän!");

            dict.Add(tutorual, "Olet juuri ansainnut joitain sydämiä!\n\nNyt voit avata uuden lahjan kaupassa!");
            dict.Add(welcome, "Hei Joulupukki!\n\nTästä eteenpäin meidän on lähetettävä lahjoja lapsille ympäri maailmaa.\n\nKosketa näyttöä, kun haluat rajata lahjan.");
        }
    }

    public string GetTextFromLocal(string _key){
        return dict[_key];
    }

    public string GetLetter(){
        var r = Random.Range(0, 6);
        if(r == 0){
            LetterHolder.letterReward = 2;
            return dict[good1];
        }
        else if(r == 1){
            LetterHolder.letterReward = 2;
            return dict[good2];
        }
        else if (r == 2)
        {
            LetterHolder.letterReward = 1;
            return dict[normal1];
        }
        else if (r == 3)
        {
            LetterHolder.letterReward = 1;
            return dict[normal2];
        }
        else if (r == 4)
        {
            LetterHolder.letterReward = 0;
            return dict[bad1];
        }
        else if (r == 5)
        {
            LetterHolder.letterReward = 0;
            return dict[bad2];
        }
        else {
            LetterHolder.letterReward = 2;
            return dict[good1];
        }

    }
}
