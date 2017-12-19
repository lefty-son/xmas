﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizer : MonoBehaviour {
    public static Localizer instance;

    #region UPGRADES

    private readonly string upgrade_santa = "upgrade_santa";
    private readonly string upgrade_convey = "upgrade_convey";
    private readonly string sled_max = "sled_max";
    private readonly string sled_speed = "sled_speed";

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


    #region DESCS

    private readonly string doggy_desc = "doggy_desc";
    private readonly string rubber_duck_desc = "rubber_duck_desc";
    private readonly string teddy_bear_desc = "teddy_bear_desc";
    private readonly string snow_man_desc = "snow_man_desc";

    #endregion

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

            dict.Add(doggy_desc, "");
            dict.Add(rubber_duck_desc, "");
            dict.Add(teddy_bear_desc, "");
            dict.Add(snow_man_desc, "");
        }
        // KO
        else if(lang == 1){
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

            dict.Add(doggy_desc, "");
            dict.Add(rubber_duck_desc, "");
            dict.Add(teddy_bear_desc, "");
            dict.Add(snow_man_desc, "");
        }
        // CN
        else if(lang == 2){
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

            dict.Add(doggy_desc, "");
            dict.Add(rubber_duck_desc, "");
            dict.Add(teddy_bear_desc, "");
            dict.Add(snow_man_desc, "");
        }
        // JP
        else if (lang == 3)
        {
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

            dict.Add(doggy_desc, "");
            dict.Add(rubber_duck_desc, "");
            dict.Add(teddy_bear_desc, "");
            dict.Add(snow_man_desc, "");
        }
    }

    public string GetTextFromLocal(string _key){
        return dict[_key];
    }
}
