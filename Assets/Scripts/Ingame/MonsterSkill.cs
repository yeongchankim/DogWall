﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkill : MonoBehaviour
{
    #region 변수
    Data_Manager dataManager;
    private DataManager Data;
    TeamSelect teamSelect;
    Turn turn;
    CharacterMgr characterMgr;
    MonsterMgr monsterMgr;
    Skill skill;
    SepcialMonster specialMonster;

    public int[,] MonsterSkillList = new int[4,12];//몬스터 스킬 목록
    int[,] monsterTurns = new int[4,4];//몬스터 인덱스(열), 몬스터 남은 턴수(공격력, 데미지감소, 회복, 출혈)
    int currentAttack = 0;//현재 공격력
    int increaseAttack = 100;//공격력 증가량
    public int mobRatio = 100;//몬스터 데미지 증가율
    public int mobSkillNumber;//최종 스킬 번호

    // Start is called before the first frame update
    void Start()
    {
        Data = GameObject.Find("Data_Managers").gameObject.GetComponent<DataManager>();//데이터 가져오기
        teamSelect = GameObject.FindWithTag("TeamSelect").GetComponent<TeamSelect>();//TeamSelect 스크립트에서 변수 가져오기
        turn = GameObject.FindWithTag("TurnMgr").GetComponent<Turn>();//Trun 스크립트에서 변수 가져오기
        characterMgr = GameObject.FindWithTag("Character").GetComponent<CharacterMgr>();//CharacterMgr 스크립트에서 변수 가져오기
        monsterMgr = GameObject.FindWithTag("Monster").GetComponent<MonsterMgr>();//MonsterMgr 스크립트에서 변수 가져오기
        dataManager = GameObject.FindWithTag("DBManager").GetComponent<Data_Manager>();//Data_Manager 스크립트에서 변수 가져오기
        skill = GameObject.FindWithTag("Skill").GetComponent<Skill>();//Skill 스크립트에서 변수 가져오기
        specialMonster = GameObject.FindWithTag("MonsterSpecialSkill").GetComponent<SepcialMonster>();//SepcialMonster스크립트에서 변수 가져오기
    }
    #endregion

    //몬스터 일반 스킬 세팅(턴수 저장 때문에 만들었다)
    public void monsterNormalSkillSet()
    {
        for(int i = 0; i < monsterMgr.MonsterNum.Count; i++)//각 몬스터의 스킬을 배열에 넣기
        {
            int MobSkillIndex01 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn0_general1].TurnCount;
            int MobSkillIndex02 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn0_general2].TurnCount;
            int MobSkillIndex11 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn1_general].TurnCount;
            int MobSkillIndex12 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn1_general__1].TurnCount;
            int MobSkillIndex21 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn2_general].TurnCount;
            int MobSkillIndex22 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn2_general__1].TurnCount;
            int MobSkillIndex31 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn3_general1].TurnCount;
            int MobSkillIndex32 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn3_general2].TurnCount;
            int MobSkillIndex41 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn4_general1].TurnCount;
            int MobSkillIndex42 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn4_general2].TurnCount;
            int MobSkillIndex51 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn5_general1].TurnCount;
            int MobSkillIndex52 = Data.saveData.MonsterSkill[Data.saveData.MonsterData[i].turn5_general2].TurnCount;
            MonsterSkillList[i,0] = MobSkillIndex01; MonsterSkillList[i, 1] = MobSkillIndex02;
            MonsterSkillList[i, 2] = MobSkillIndex11; MonsterSkillList[i, 3] = MobSkillIndex12;
            MonsterSkillList[i, 4] = MobSkillIndex21; MonsterSkillList[i, 5] = MobSkillIndex22;
            MonsterSkillList[i, 6] = MobSkillIndex31; MonsterSkillList[i, 7] = MobSkillIndex32;
            MonsterSkillList[i, 8] = MobSkillIndex41; MonsterSkillList[i, 9] = MobSkillIndex42;
            MonsterSkillList[i, 10] = MobSkillIndex51; MonsterSkillList[i, 11] = MobSkillIndex52;
        }
    }
    
    //몇번 스킬을 사용하는가?(일반)
    int UseNormalSkill(int mobIndex, int processTurn)
    {
        int randomNum = Random.Range(0, 2);
        int useSkillNum = 0;
        processTurn = (processTurn-2)%6;
        switch (processTurn)
        {
            case 0:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn0_general1;
                }else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn0_general2;
                }
                break;
            case 1:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn1_general;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn1_general__1;
                }
                break;
            case 2:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn2_general;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn2_general__1;
                }
                break;
            case 3:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn3_general1;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn3_general2;
                }
                break;
            case 4:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn4_general1;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn4_general2;
                }
                break;
            case 5:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn5_general1;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn5_general2;
                }
                break;
        }
        return useSkillNum;
    }

    //몇번 스킬을 사용하는가?(특수)
    int UseSpecialSkill(int mobIndex, int processTurn)
    {
        int randomNum = Random.Range(0, 2);
        int useSkillNum = 0;
        processTurn = (processTurn - 2) % 6;
        switch (processTurn)
        {
            case 0:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn0_special1;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn0_special2;
                }
                break;
            case 1:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn1_special1;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn1_special2;
                }
                break;
            case 2:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn2_special1;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn2_special2;
                }
                break;
            case 3:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn3_special1;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn3_special2;
                }
                break;
            case 4:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn4_special1;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn4_special2;
                }
                break;
            case 5:
                if (randomNum == 0)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn5_special1;
                }
                else if (randomNum == 1)
                {
                    useSkillNum = Data.saveData.MonsterData[mobIndex].turn5_special2;
                }
                break;
        }
        return useSkillNum;
    }
    //최종 스킬 선택
    public bool IsNormalSkill()
    {
        int randomIndex = Random.Range(0, 2);
        if (randomIndex == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //몬스터->플레이어(몬스터 인덱스, 스킬번호를 받아서 진행)
    public int monsterSkillDamage(int mobIndex,int processTurn)//몬스터 번호, 진행 턴
    {
        int realNumber = monsterMgr.MonsterNum[mobIndex];//실제 몬스터 번호
        int normalSkillNumber = UseNormalSkill(realNumber,processTurn);//일반 스킬 인덱스
        int specialSkillNum = UseSpecialSkill(realNumber, processTurn);//특수 스킬 번호
        mobSkillNumber = normalSkillNumber;//임시, 몬스터 스킬 번호
        //특수 스킬인가?
        if (specialSkillNum > 0 && !IsNormalSkill())
        {
            mobRatio = specialMonster.SpecialSkill(mobIndex,specialSkillNum);
            return 0;
        }
        int monsterAttackDamage = 0;//총 데미지 초기화
        currentAttack = Data.saveData.MonsterData[realNumber].Atk*increaseAttack/100;//현재 공격력
        
        //턴 기반 버프(일반 스킬)
        TurnBuffInit(mobIndex,mobSkillNumber);//턴버프 초기화
        MonsterNormalTurnBuff(mobIndex, mobSkillNumber);

        //HP회복
        HealMonsterHP(Data.saveData.MonsterSkill[mobSkillNumber].HealHP,mobIndex,mobIndex);

        int attackDamage = currentAttack*(Data.saveData.MonsterSkill[mobSkillNumber].Damage)/100;//데미지(공격력*퍼뎀)
        int countSkill = Data.saveData.MonsterSkill[mobSkillNumber].AttackCount;//공격 횟수
        monsterAttackDamage = (attackDamage*mobRatio/100)/monsterMgr.monsters.Count;//공격(여러마리 있으면 분산)
   
        //다회 공격
        for(int j = 1; j < countSkill; j++)//countSkill번
        {
            monsterAttackDamage += attackDamage;//공격
        }
        return monsterAttackDamage;
    }
    
    //몬스터 HP회복
    void HealMonsterHP(int AmountMobHP,int mobIndex,int mobNum)//회복량, 몬스터 인덱스, 실제 몬스터 넘버
    {
        Mathf.Max(Data.saveData.MonsterData[mobNum].Hp, monsterMgr.currentMonsterHP[mobIndex] + AmountMobHP);
    }
    //다수 공격(몬스터->캐릭터)
    public void MultiAttack(int hitDamage, int mobIndex,int mobSkillNumber)//스킬데미지, 몹 인덱스, 스킬넘버
    {
        bool[] selectedMob = { false, false, false, false };//몬스터 인덱스
        int realNumber = monsterMgr.MonsterNum[mobIndex];//실제 몬스터 번호
        int targets = Data.saveData.MonsterSkill[mobSkillNumber].Targets;//타겟 수
        int countTargets = 0;//현재 공격 마릿수

        while(countTargets<targets)
        {
            int selectedIndex = Random.Range(0, 4);//캐릭터 위치 선택(0~3)
            if (!selectedMob[selectedIndex])
            {
                selectedMob[selectedIndex] = true;
                
                int monsterAttribute = Data.saveData.MonsterData[realNumber].Type;//몬스터 속성
                int playerAttribute = Data.saveData.CharacterData[teamSelect.selectedTeamNumber[selectedIndex]].Attribute;//플레이어 속성
                int attributeDamage = characterMgr.CheckAttribute(playerAttribute, monsterAttribute);//속성 데미지

                int mobHitDamage = attributeDamage * hitDamage/(100*targets);
                //하트 링크
                if (Data.saveData.MonsterSkill[mobSkillNumber].HeartLink > 0)
                {
                    mobHitDamage = mobHitDamage /2;
                }
                //데스 링크
                if (Data.saveData.MonsterSkill[mobSkillNumber].DeathLink > 0)
                {
                    mobHitDamage = mobHitDamage * 3 / 2;
                }
                characterMgr.PlayerBloodDamage(selectedIndex, mobHitDamage);//공격
                countTargets++;
            }
        }
    } 
    //몬스터 턴 초기화
    void TurnBuffInit(int mobIndex,int mobSkillNumber)
    {
        int turnCounts = Data.saveData.MonsterSkill[mobSkillNumber].TurnCount;//턴 수
        if (turnCounts > 0)
        {
            //공격력
            if (Data.saveData.MonsterSkill[mobSkillNumber].Attack != 100)
            {
                monsterTurns[0, mobIndex] = turnCounts;
            }
            //방어력
            if (Data.saveData.MonsterSkill[mobSkillNumber].DecreaseDamage != 100)
            {
                monsterTurns[1, mobIndex] = turnCounts;
            }
            //회복
            if (Data.saveData.MonsterSkill[mobSkillNumber].HealHP != 0)
            {
                monsterTurns[2, mobIndex] = turnCounts;
            }
            //출혈
            if (Data.saveData.MonsterSkill[mobSkillNumber].Blood != 0)
            {
                monsterTurns[3, mobIndex] = turnCounts;
            }
        }
    }
    //몬스터 턴 버프(일반)
    void MonsterNormalTurnBuff(int mobIndex, int mobSkillNumber)
    {
        //공격력증가
        if(monsterTurns[0, mobIndex] > 0)//진행 중
        {
            increaseAttack = Data.saveData.MonsterSkill[mobSkillNumber].Attack+100;//공격력 증가
            //공격력 증가 표시
            monsterTurns[0, mobIndex] -= 1;//남은 턴 수 감소
        }
        else if (monsterTurns[0,mobIndex] == 0)//원래대로
        {
            increaseAttack = 100;
        }

        //데미지 감소
        if (monsterTurns[1, mobIndex] > 0)
        {
            skill.monsterDefense = Data.saveData.MonsterSkill[mobSkillNumber].DecreaseDamage;//방어력 갱신
            //방어력 증가표시
            monsterTurns[1, mobIndex] -= 1;
        }
        else if (monsterTurns[1, mobIndex] == 0)//원래대로
        {
            skill.monsterDefense = 100;
        }

        //회복
        if(monsterTurns[2, mobIndex] > 0)
        {
            int amountHeal = monsterMgr.monsterFullHP[mobIndex]*Data.saveData.MonsterSkill[mobSkillNumber].HealHP/100;//회복량
            monsterMgr.currentMonsterHP[mobIndex] = Mathf.Max(monsterMgr.monsterFullHP[mobIndex], monsterMgr.currentMonsterHP[mobIndex] + amountHeal);
            monsterTurns[2, mobIndex] -= 1;
        }
        
        //출혈
        if (monsterTurns[3, mobIndex] > 0)
        {
            characterMgr.playerHP -= Data.saveData.MonsterSkill[mobSkillNumber].Blood;//출혈데미지
            monsterTurns[3, mobIndex] -= 1;
        }
    }
}
