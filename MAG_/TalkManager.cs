using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        // 씬 시작, 튜토리얼
        talkData.Add(100, new string[]{"베테랑의 감으로 보아하니 보물의 위치는 대략 이 주변인 것 같다."
                                        , "오는 길이 굉장히 험난했지만 괜찮다.\n나는 프로 모험가니까."
                                        , "그렇게 험난한 길을 지나 이 곳에 온 것은 좋았는데.."
                                        , "아무리 봐도 이 이상 갈 수 있는 길이 보이지 않는다."
                                        , "이제 와서 여기서 포기해야 한다고? 믿을 수 없다."
                                        , "분명 숲의 내부로 들어갈 수 있는 방법이 있을 것이다."
                                        , "일단 주변을 탐색하면서 숲의 내부로 갈 방법을 찾아보자."});
        talkData.Add(110, new string[]{"내 이름은 찰스.\n사람들은 나를 전설의 보물 사냥꾼이라고 부른다."
                                        , "수많은 보물들을 발견했던 나는\n이제는 평범한 보물을 찾는 것에는 흥미를 잃었다."
                                        , "오랜 기간 동안 '특별한' 보물들은 보이지도 않고\n이번에도 허탕친건가? 하고 생각하던 중..."
                                        , "아무리 봐도 '특별한' 보물이 있을 것 같은 숲을 발견했다!\n베테랑의 감으로 이건 100% 특별한 보물이다!"
                                        , "좋아! 오랜만에 찾아온 기회를 놓칠 수 없지.\n만반의 준비를 해야겠군."
                                        , "우선 저 곳에 있는 표지판을 한 번 조사해보자."
                                        , "W, A, S, D키를 이용해 움직일 수 있습니다.\n마우스 이동을 통해 시점을 변경할 수 있습니다."
                                        , "빛을 향해 움직여 보세요!"});
        talkData.Add(120, new string[]{"Space Bar를 이용해 점프하세요."});
        talkData.Add(130, new string[]{"Left Shift키를 누르고 빠르게 움직이세요."});
        talkData.Add(140, new string[]{"F키를 눌러 대상을 조사하세요."});
        talkData.Add(150, new string[]{"'이 곳의 장치를 푸는 자. 거대한 영광이 기다리고 있다'"
                                        ,"역시! 내 예상대로다.\n거대한 영광이란 나에겐 오직 위대한 보물 뿐이다."
                                        ,"이러고 있을 시간이 없다..\n어서 보물을 찾으러 떠나보자!"});
        talkData.Add(160, new string[]{"......."
                                        ,"거대하고 화려한 보물상자.."
                                        ,"이건 틀림없다.\n이 보물 상자야말로 내가 찾던 '특별한' 보물상자다."
                                        ,"보물 상자를 열기도 전인데 미친듯이 두근거린다.\n하지만 아직 기뻐하긴 이르다."
                                        ,"겉으로만 봐도 이 상자의 장치는 방금 상자보다 훨씬 복잡해보인다."
                                        ,"'장치를 푸는 자 영광을 얻게 될 것이다'\n분명 이번에도 아까 전처럼 장치를 풀어야겠지."
                                        ,"그런데, 이 곳은 아까와는 조금 다른 분위기다.\n안개도 많이 껴있고..."
                                        ,"아무래도 좀 더 조심하면서 주변을 탐색하는 것이 좋겠다."
                                        ,"이번에도 숲을 탐색하면서 이 거대한 녀석을 열어볼 방법을 찾아보자."});
        // 열쇠
        talkData.Add(200, new string[]{"열쇠를 찾았다!"
                                        , "탈출에 사용할 수 있을 것 같다. 상자에 사용해보자."});
        talkData.Add(210, new string[]{"목숨을 담보로 얻은 열쇠라...."
                                        , "보물을 반드시 손에 넣어야겠군.."});
        talkData.Add(300, new string[]{"폭탄의 무시무시한 위력이 바위를 부숴버렸다."
                                        , "역시! 이 너머는 숲의 내부인 것 같다. 어서 들어가보자."});

        talkData.Add(1000, new string[]{"거대한 바위지만 구석구석 금이 있다."
                                        , "땅에는 'BOMB' 라고 쓰여있다."});
        // 발판
        talkData.Add(2000, new string[]{"수상해보이는 발판들이다."
                                        , "한쪽 발판들이 붉은색으로 칠해져 있다."
                                        , "표지판에는 이렇게 쓰여있다."
                                        , "'냉온의 균형을 이루어라.'"});
        talkData.Add(2100, new string[]{"'냉온의 균형을 이루어라.'"
                                        , "이전에 보았던 장치와 같은 장치다."
                                        , "표지판의 설명도 같은 것으로 보아 해결 방법도 같을 것이다."
                                        , "하지만.. 이번에는 딱 봐도 밟으면 안될 것 같은 것이 놓여있다."
                                        , "발이 아작나고 싶진 않은데..\n함정을 무시하고 누를 수 있는 방법이 없을까?"});
        talkData.Add(2200, new string[]{"바위를 들어보니 은근히 들고 다닐만 하다."
                                        , "가지고 있으면 쓸 곳이 있지 않을까?"});
        talkData.Add(2300, new string[]{"바위를 발판 위에 올려놨다."});
        // 패스워드
        talkData.Add(3000, new string[]{"나무에 색이 다른 버튼들이 달려있다."
                                        , "아무렇게나 눌러봤지만 아무런 반응이 없다."
                                        , "표지판에는 이렇게 쓰여있다."
                                        , "'21부터 4의 흐름대로 눌러라.'"});
        talkData.Add(3100, new string[]{"'도망쳐...'"});
        talkData.Add(3200, new string[]{"나무에 또 버튼들이 달려있다."
                                        , "눌러보았으나 이상하게 꿈쩍하지 않는다."});
        talkData.Add(3300, new string[]{"................"
                                        ,"................"
                                        , "도저히 안심할 수가 없는 곳이군...."
                                        , "보물을 얻고 어서 빠져나가야겠어."});
        // 보물상자
        talkData.Add(4000, new string[]{"바위 바로 옆에 있던 보물상자다."
                                        , "혹시? 하는 마음에 열어봤지만 역시 열리지 않았다."
                                        , "열쇠 구멍이 있다. 주변에서 열쇠를 찾아보자."
                                        , "이 곳을 나가는 중요한 힌트가 있을지도 모른다."});
        talkData.Add(4010, new string[]{"열쇠를 꽂아 넣으니 열쇠 구멍이 하나 더 나왔다."
                                        , "이런! 열쇠 하나를 더 찾아보자."});
        talkData.Add(4020, new string[]{"열쇠 2개를 꽂아 넣었더니 상자가 열렸다!"
                                        , "안에는 폭탄? 이 들어있다."
                                        , "이걸 탈출에 사용할 수 있을까?"});
        talkData.Add(4030, new string[]{"BOMB라고 쓰여진 이 곳.. 금이 있는 바위.."
                                        , "이 곳에 폭탄을 사용하는게 틀림없다."
                                        , "폭탄을 설치해보자."});
        // 함정 무덤

        talkData.Add(5000, new string[]{"'그대는 이 곳을 지나갈 용기를 가진 자인가?'"
                                        , "스치기만 해도 치명상인 칼날들 사이로 은색의 열쇠가 보인다."});

        talkData.Add(6100, new string[]{"열쇠를 꽂아 넣었지만, 역시 하나로는 열리지 않는다."
                                        , "열쇠를 더 찾아보자."});
        talkData.Add(6200, new string[]{"열쇠를 하나 더 꽂아 넣었다."
                                        , "역시 최고의 보물답군.\n아직 열리지 않는다."
                                        ,"하나 정도만 더 있으면 열릴거 같은데.."});
        talkData.Add(6000, new string[]{"보물 상자의 열쇠 구멍을 보니 열쇠가 족히 3개는 필요해보인다."
                                        , "열쇠를 찾아보자."});
        talkData.Add(6300, new string[]{"이..이건....."});

        // 퀘스트 대화
    }

    public string GetTalk(int id, int talkIndex) //Object의 id , string배열의 index
    {
        if (talkIndex == talkData[id].Length) {
            return null;
        }
        else {
            return talkData[id][talkIndex]; //해당 아이디의 해당
        }
    }
}
