using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[System.Serializable]
public class PlayerDataClass//캐릭터 DB
{
    public int idx = 0;//인덱스
    public string img_path = "";//이미지 경로
    public string Name = "";//캐릭터명
    public int HP = 0;//HP
    public int ATK = 0;//공격력
    public int Attribute = 0;//속성
    public int Energe = 0;//에너지
    public int Appear = 1;//출현 
    public int Upgrade = 0;//업그레이드 수
    public int Same = 0;//같은 건가
    public int Star = 0;//별
    public int IsAction = 0;//스킬 사용이 가능한가?
    public Sprite Img = null;//이미지
    public int Stage = 1;

    public PlayerDataClass(int i=0,string impa = "", string n = "무명", int h = 0, int a = 0, int A = 1,int e=0,int app=0,int up=0, int S = 1,int star = 0, int act = 0, int stage = 1)
    {
        this.idx = i;
        this.img_path = impa;
        this.Name = n;
        this.HP = h;
        this.ATK = a;
        this.Attribute = A;
        this.Energe = e;
        this.Appear = app;
        this.Upgrade = up;
        this.Same= S;
        this.Star = star;
        this.IsAction = act;
        this.Stage = stage;
    }
}
[System.Serializable]
public class CharacterSkillDataClass//스킬DB
{
    public string Character = "";//캐릭터 명
    public string SkillName = "";//스킬 명
    public int line = 1;//스킬 순서
    public int Skill1 = 0;//스킬 인덱스
    public int Skill2 = 0;//스킬 인덱스
    public int Skill3 = 0;//스킬 인덱스
    public int Skill4 = 0;//스킬 인덱스
    public string Descrition = "";//스킬 설명
    public int Type = 1;//타입
    public int Appear = 0;//등장

    public CharacterSkillDataClass(string cn = "로그",string sn = "럭키세븐",int l=0,int s1=0,int s2=0,int s3=0,int s4=0,string des = "",int t=0,int a=0)
    {
        this.Character = cn;
        this.SkillName = sn;
        this.line = l;
        this.Skill1 = s1;
        this.Skill2 = s2;
        this.Skill3 = s3;
        this.Skill4 = s4;
        this.Descrition = des;
        this.Type = t;
        this.Appear = a;
    }
}
[System.Serializable]
public class CharacterSkillIndexDataClass//스킬DB
{
    public string Name = "";//이름
    public int Attack = 0;//공격
    public int CharacterAttack = 0;//캐릭터 공격력 증가
    public int DecreaseDamage = 0;//데미지감소
    public int HealHP = 0;//HP회복
    public bool Provocation = false;//도발
    public bool NotAction = false;//행동불능
    public int HealEnerge = 0;//에너지 회복
    public int Blood = 0;//출혈
    public bool AllTargets = false;//전체 공격여부
    public int TurnCount = 1;//지속 턴수
    public bool HeartLink = false;//하트 링크 여부
    public bool DeathLink = false;//데스 링크 여부
    public int Energy = 1;//에너지 사용량

    public CharacterSkillIndexDataClass(string sn = "럭키세븐", int a = 0, int ca = 0, int dd = 0, int hh = 0, bool p = false, bool na = false, int he = 0, int b = 0,bool allt=false, int tc = 1,bool hli = false,bool dli = false, int e = 1)
    {
        this.Name = sn;
        this.Attack = a;
        this.CharacterAttack = ca;
        this.DecreaseDamage = dd;
        this.HealHP = hh;
        this.Provocation = p;
        this.NotAction = na;
        this.HealEnerge = he;
        this.Blood = b;
        this.AllTargets = allt;
        this.TurnCount = tc;
        this.HeartLink = hli;
        this.DeathLink = dli;
        this.Energy = e;
    }
}

[System.Serializable]
public class MonstersDataClass//몬스터 DB
{
    public string World = "월령";//1:월령, 2:엠피레오, 3: 제한 구역, 4: 전체
    public string Character = "";//이름
    public int Difficulty = 1;//속성
    public int Type = 1;//타입
    public int Hp = 0;//HP
    public int Atk = 0;//공격력
    //각 턴에 뭐를 쓸건가
    public int turn0_general1 = 0;public int turn0_general2 = 0;public int turn0_special1 = 0;public int turn0_special2 = 0;
    public int turn1_general = 0;public int turn1_general__1; public int turn1_special1 = 0;public int turn1_special2 = 0;
    public int turn2_general = 0;public int turn2_general__1 = 0;public int turn2_special1 = 0;public int turn2_special2 = 0;
    public int turn3_general1 = 0;public int turn3_general2 = 0;public int turn3_special1 = 0;public int turn3_special2 = 0;
    public int turn4_general1 = 0;public int turn4_general2 = 0;public int turn4_special1 = 0;public int turn4_special2 = 0;
    public int turn5_general1 = 0;public int turn5_general2 = 0;public int turn5_special1 = 0;public int turn5_special2 = 0;

    public MonstersDataClass(string w = "월령", string n = "1", int d = 1 ,int t = 1, int h = 0, int at = 0,int tc= 1,
        int t0G1=0,int t0G2=0,int t0S1=0,int t0S2=0,
        int t1G1 = 0, int t1G2 = 0, int t1S1 = 0, int t1S2 = 0,
        int t2G1 = 0, int t2G2 = 0, int t2S1 = 0, int t2S2 = 0,
        int t3G1 = 0, int t3G2 = 0, int t3S1 = 0, int t3S2 = 0,
        int t4G1 = 0, int t4G2 = 0, int t4S1 = 0, int t4S2 = 0,
        int t5G1 = 0, int t5G2 = 0, int t5S1 = 0, int t5S2 = 0)
    {
        this.World = w;
        this.Character = n;
        this.Difficulty = d;
        this.Type = t;
        this.Hp = h;
        this.Atk = at;
        //각 턴 스킬 번호
        this.turn0_general1 = t0G1;this.turn0_general2 = t0G2;this.turn0_special1 = t0S1;this.turn0_special2 = t0S2;
        this.turn1_general = t1G1;this.turn1_general__1 = t1G2;this.turn1_special1 = t1S1;this.turn1_special2 = t1S2;
        this.turn2_general = t2G1;this.turn2_general__1 = t2G2;this.turn2_special1 = t2S1;this.turn2_special2 = t2S2;
        this.turn3_general1 = t3G1;this.turn3_general2 = t3G2;this.turn3_special1 = t3S1;this.turn3_special2 = t3S2;
        this.turn4_general1 = t4G1;this.turn4_general2 = t4G2;this.turn4_special1 = t4S1;this.turn4_special2 = t4S2;
        this.turn5_general1 = t5G1;this.turn5_general2 = t5G2;this.turn5_special1 = t5S1;this.turn5_special2 = t5S2;
    }
}
public class BossMonsterDataClass//보스몬스터 DB
{
    public string World = "월령";//1:월령, 2:엠피레오, 3: 제한 구역, 4: 전체
    public int Attribute = 1;//속성
    public string Name = "";//이름
    public int Stage = 1;//스테이지
    public int HP = 0;//HP
    public int Attack = 0;//공격력

    public BossMonsterDataClass(string w = "월령", int a = 1, string n = "1", int s = 1, int h = 0, int at = 0)
    {
        this.World = w;
        this.Attribute = a;
        this.Name = n;
        this.Stage = s;
        this.HP = h;
        this.Attack = at;
    }
}
[System.Serializable]
public class MonsterSkillDataClass
{
    public string Name = "";//스킬 설명
    public int Damage = 0;//데미지
    public int AttackCount = 0;//공격 횟수
    public int Targets = 0;//타겟 수
    public int Blood = 0;//출혈 데미지
    public int TurnCount = 0;//스킬 턴수
    public int Attack = 0;//몬스터 공격력
    public int DecreaseDamage = 0;//피격 데미지 감소량
    public bool Self = false;//자기자신한테 공격하는 것인가?
    public int HealHP = 0;//hp회복량
    public int HeartLink = 3000;//하트링크 데미지
    public int DeathLink = 3000;//데스링크 데미지

    public MonsterSkillDataClass( string name = null, int d = 1, int ac = 1,int b=1,int tc = 1,int a=1,int de=1,bool s = false,int hh=1,int hl = 1,int dl=1)
    {
        this.Name = name;
        this.Damage = d;
        this.AttackCount = ac;
        this.Blood = b;
        this.TurnCount = tc;
        this.Attack = a;
        this.DecreaseDamage = de;
        this.Self = s;
        this.HealHP = hh;
        this.HeartLink = hl;
        this.DeathLink = dl;
    }
}
[System.Serializable]
public class MonsterSpeccialSkillDataClass
{
    public string Name = "";//스킬 설명
    public int NotAction = 0;//활동 여부
    public int Targets = 0;//타겟 수
    public int TurnCount = 0;//스킬 턴수
    public int CharacterAttack = 0;//공격데미지 증가량
    public int DecreaseDamage = 0;//피격 데미지 감소량
    public bool Self = false;//자기자신한테 공격하는 것인가?
    public int Energy = 0;//플레이어 에너지 회복량
    public int HeartLink = 3000;//하트링크 데미지
    public int Deathlink = 3000;//데스링크 데미지
    public bool Provocation = false;//도발여부
    public bool IsMaxHealth = false;//가장 체력이 높은 몬스터

    public MonsterSpeccialSkillDataClass(string name = null, int na = 1, int target=1, int tc = 1, int chaAtk = 1, int de = 1, bool s = false, int e = 1, int hl = 1, int dl = 1,bool prov=false,bool ismax=false)
    {
        this.Name = name;
        this.NotAction = na;
        this.Targets = target;
        this.TurnCount = tc;
        this.CharacterAttack = chaAtk;
        this.DecreaseDamage = de;
        this.Self = s;
        this.Energy = e;
        this.HeartLink = hl;
        this.Deathlink = dl;
        this.Provocation = prov;
        this.IsMaxHealth = ismax;
    }
}
[System.Serializable]
public class QuestInfo//쿼스트 데이터
{
    public string Appear = "";
    public string Episode = "";
    public int Quest = 0;
    public int Stage = 0;
    public int Difficulty = 0;
    public int Type = 0;
    public int MonsterIndex = 0;
    public int Clear = 0;

    public QuestInfo(string appear, string episode, int quest, int stage, int difficulty, int type, int mobidx,int clear)
    {
        this.Appear = appear;
        this.Episode = episode;
        this.Quest = quest;
        this.Stage = stage;
        this.Difficulty = difficulty;
        this.Type = type;
        this.MonsterIndex = mobidx;
        this.Clear = clear;
    }
}
[System.Serializable]
public class UI
{
    public List<int> money;//재화
    public string home_img_path;
    public float bgm, sfx;
    public UI()
    {
        money = new List<int>();
        home_img_path = "";
    }
    public UI(List<int> m, string h_p)
    {
        this.money = m;
        this.home_img_path = h_p;
    }

}
[System.Serializable]
public class SaveDataClass
{
    public List<PlayerDataClass> my_characterlist;//캐릭터 리스트
    public List<PlayerDataClass> CharacterData;//캐릭터 리스트(찐)
    public List<CharacterSkillDataClass> CharacterSkill;//캐릭터 스킬 리스트
    public List<CharacterSkillIndexDataClass> CharacterSkillIndex;//캐릭터 스킬 Index 리스트
    public List<MonstersDataClass> MonsterData;//몬스터 리스트(지울 예정)
    public List<BossMonsterDataClass> BossData;//보스몬스터 리스트
    public List<MonsterSkillDataClass> MonsterSkill;//몬스터 스킬 리스트
    public List<MonsterSpeccialSkillDataClass> MonsterSpecialSkill;//몬스터 특수스킬
    public List<QuestInfo> QuestData;//쿼스트 데이터
    //스테이지 진행정도
    public List<PlayerDataClass> my_team;
    public UI ui;
    public SaveDataClass()
    {
        //리스트 불러오기
        my_characterlist= new List<PlayerDataClass>();
        CharacterData = new List<PlayerDataClass>();
        my_team = new List<PlayerDataClass>();
        for(int i = 0; i < 12; i++)
            my_team.Add(new PlayerDataClass());
        CharacterSkill = new List<CharacterSkillDataClass>();
        CharacterSkillIndex = new List<CharacterSkillIndexDataClass>();
        MonsterData = new List<MonstersDataClass>();
        BossData = new List<BossMonsterDataClass>();
        MonsterSkill = new List<MonsterSkillDataClass>();
        MonsterSpecialSkill = new List<MonsterSpeccialSkillDataClass>();
        QuestData = new List<QuestInfo>();
        ui =  new UI();
    }
    /*
    public void SetImgforOnce(string folder)//특정 폴더에 있는 이미지들을 캐릭터에 맞게 배치하기(list용)
    {     
        Sprite[] imgs;
        imgs = Resources.LoadAll<Sprite>(folder);//리소스 폴더에 있는 이미지를 모두 가져옴
        List<string> names = new List<string>();
        foreach(Sprite i in imgs)//모든 이미지들의 경로를 가져옴
        {
            string path = AssetDatabase.GetAssetPath(i);
            path = path.Replace("Assets/Resources/" + folder,string.Empty);//불필요한 부분제거
            path = path.Replace(".png",string.Empty);//불필요한 부분 제거
            names.Add(path);//불필요한 부분을 제거한 이름을 리스트로 저장
        }
        foreach(PlayerDataClass a in list)//리스트의 모든 캐릭터들을 대상으로 동작
            if(a.img_path != "")//경로가 있다면
            {
                foreach(string name in names)//앞서 저장한 이름들과 비교
                {
                    if(name.Contains(a.img_path))//이름이 캐릭터의 영문명을 포함한다면
                    {
                        if(name == a.img_path)//똑같은 거라면 Img에 저장
                        {
                            int temp = names.IndexOf(name);
                            a.Img = imgs[temp];
                        }
                        else//아니면 Img_for_dialog에 저장
                        {
                            int temp = names.IndexOf(name);
                            a.Img_for_dialog = imgs[temp];
                            a.img_for_dialog_path = name;//경로도 추가해줌
                        }
                    }
                    if(a.Img != null && a.Img_for_dialog != null)//모두 찾으면 탈출해야지
                        break;
                }    
            }
        foreach(Character a in my_characterlist)//list에 모든 정보가 저장되어있으므로 idx를 통해서 찾기만 하면 됨
            if(a.img_path != "")
            {
                a.Img = list[a.idx].Img;
                a.Img_for_dialog = list[a.idx].Img;
            }
        foreach(Character a in my_team)//list에 모든 정보가 저장되어있으므로 idx를 통해서 찾기만 하면 됨
            if(a.img_path != "")
            {
                a.Img = list[a.idx].Img;
                a.Img_for_dialog = list[a.idx].Img;
            }
    }
    */
}

[System.Serializable]
public class StageInfo{
    public int appear;
    public int episode;
    public int quest;
    public int stage;
    public int difficulty;
    public int type;
    public string character;

    /*
    public void FindQuest()
    {
        var loadedJson = Resources.Load<TextAsset>("userData/QuestData");
        StageInfo basicStageInfo = JsonUtility.FromJson<StageInfo>(loadedJson.ToString());

        Debug.Log($"{basicStageInfo.episode}, {basicStageInfo.difficulty}, {basicStageInfo.character}");
    }
    */
}

