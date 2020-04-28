using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleFM_Project
{

    enum Buff
    {

        STRENGTH_UP = 10,
        STAMINA_UP,
        JUMPING_UP,
        SHOTPOWER_UP,
        REFLECTION_UP,
        AGILLITY_UP,
        SPRINT_UP,
        ACCELERATION_UP,
        PASSINGACCURACY_UP,
        HEADINGACCURACY_UP,
        SHOTACCURACY_UP,
        DRIBBLE_UP,
        TACKLE_UP,
        SLIDINGTACKLE_UP,
        MANTOMAN_UP,
        POSITIONING_UP,
        VISION_UP,
        GK_HANDLING_UP,
        GK_ONEONONE_UP,
        GK_DIVING_UP

    }

    enum Debuff
    {

        STRENGTH_DOWN,
        STAMINA_DOWN,
        JUMPING_DOWN,
        SHOTPOWER_DOWN,
        REFLECTION_DOWN,
        AGILLITY_DOWN,
        SPRINT_DOWN,
        ACCELERATION_DOWN,
        PASSINGACCURACY_DOWN,
        HEADINGACCURACY_DOWN,
        SHOTACCURACY_DOWN,
        DRIBBLE_DOWN,
        TACKLE_DOWN,
        SLIDINGTACKLE_DOWN,
        MANTOMAN_DOWN,
        POSITIONING_DOWN,
        VISION_DOWN,
        GK_HANDLING_DOWN,
        GK_ONEONONE_DOWN,
        GK_DIVING_DOWN

    }

    public class Player : Human
    {

        static List<String> buffList = new List<String>();      //버프 리스트 
        static List<String> debuffList = new List<String>();    //디버프 리스트

        public override void SnackBar()
        {

            base.SnackBar();

        }

        int backNumb;       //등번호 
        string position;    //포지션 
        string prefFoot;    //선호하는 발
        int weakFoot;       //약한 발
        int overall;

        public Player(string name, int backNumb, string position, string prefFoot, int weakFoot, int overall) //Player 클래스 생성자
        {

            this.name = name;           //human 의 name = 매개변수 name 으로 초기화
            this.backNumb = backNumb;   //Player 클래스 backNumb = 생성자 매개변수 backNumb 으로 초기화
            this.position = position;   //이 변수 포함 이아래는 위와 동일
            this.prefFoot = prefFoot;
            this.weakFoot = weakFoot;
            this.overall = overall;

        }

        public void PlayerInfo()    //플레이어 입력 정보 한번에 출력하는 메소드
        {

            Console.WriteLine("Number: {0} | Position: {1} | Name: {2} | Preferred Foot: {3} | Weak Foot: {4} | Overall: {5}"
                             , backNumb, position, name, prefFoot, weakFoot,overall);

        }

        public void BuffAndDebuff()
        {

            StreamReader buff = new StreamReader(@"C:\Users\q\source\repos\ConsoleFM_Project\ConsoleFM_Project\Database\Buff.txt");
            StreamReader debuff = new StreamReader(@"C:\Users\q\source\repos\ConsoleFM_Project\ConsoleFM_Project\Database\DeBuff.txt");

            //스트림리더 를 이용해 폴더안의 메모장 파일을 읽어옴

            string buffContents = "";
            string debuffContents = "";

            while (buff.Peek() >= 0) //리스트에 추가하는 부분
            {

                buffContents = buff.ReadLine();
                debuffContents = debuff.ReadLine();
                buffList.Add(buffContents);
                debuffList.Add(debuffContents);

            }

            Buff buffEnum;
            Debuff debuffEnum;

            Dictionary<Buff, string> buffDictonary = new Dictionary<Buff, string>();
            Dictionary<Debuff, string> debuffDictonary = new Dictionary<Debuff, string>();

            for (int i = 0; i < buffList.Count; i++)
            {

                buffDictonary.Add((Buff)i + 10, buffList[i]);
                debuffDictonary.Add((Debuff)i, debuffList[i]);

            }

            Random randomBuff = new Random();
            Random randomDebuff = new Random();

            int buffNumb = randomBuff.Next(0, 45);
            int debuffNumb = randomDebuff.Next(0, 46);

            buffEnum = (Buff)buffNumb;
            debuffEnum = (Debuff)debuffNumb;

            for (int i = 0; i < buffList.Count + 1; i++)
            {

                if (i == buffNumb) Console.WriteLine(buffList[i]);

                else continue;

            }

            for (int i = 0; i < debuffList.Count + 1; i++)
            {

                if (i == debuffNumb) Console.WriteLine(debuffList[i]);

                else continue;

            }

        }

    }

}
