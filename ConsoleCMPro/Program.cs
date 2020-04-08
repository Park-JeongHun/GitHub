using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

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

    public class Human //이름,나이,성별,관중 or 관계자 구분
    {

        public string name;    //이름
        public int age;        //나이
        public string gender;  //성별
        public bool isCrowd;   //관중인가? (true면 관중, false 면 관계자)
        public int influence;  //경기 영향력

        public virtual void SnackBar()
        {

            Random rand = new Random();           // 난수생성을 위한 Random 함수

            int expirationDate = rand.Next(0, 2); // 음식 유통기한 체크(0 = 유통기한이 지났다 , 1 = 유통기한 안지났다)

            int condition = 10;                   // 컨디션 (0 ~ 20)

            int isUseSnackBar = rand.Next(0, 2);  // 매점 이용 여부 판단(0 = 이용 하지 않았다, 1 = 이용 했다)

            if (isUseSnackBar == 0)
            {

                Console.WriteLine("매점을 이용하지 않았습니다.");

            }

            else
            {

                if (expirationDate == 0)
                {

                    condition = 0;

                    Console.WriteLine("상한 음식을 먹어 속이 좋지 않습니다.");
                    Console.WriteLine("컨디션이 최하 수치로 변경 되었습니다.");

                }

                else
                {

                    condition += 10;

                    Console.WriteLine("음식을 섭취하여 기력이 회복 되었습니다.");
                    Console.WriteLine("컨디션이 최상의 수치로 변경 되었습니다.");

                }

            }

            //Console.Read();

        }

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

        public Player(string name, int backNumb, string position, string prefFoot, int weakFoot) //Player 클래스 생성자
        {

            this.name = name;           //human 의 name = 매개변수 name 으로 초기화
            this.backNumb = backNumb;   //Player 클래스 backNumb = 생성자 매개변수 backNumb 으로 초기화
            this.position = position;   //이 변수 포함 이아래는 위와 동일
            this.prefFoot = prefFoot;
            this.weakFoot = weakFoot;

        }

        public void PlayerInfo()    //플레이어 입력 정보 한번에 출력하는 메소드
        {

            Console.WriteLine("Number: {0} | Position: {1} | Name: {2} | Preferred Foot: {3} | Weak Foot: {4}"
                             , backNumb, position, name, prefFoot, weakFoot);

        }

        public void BuffAndDebuff()
        {

            StreamReader buff = new StreamReader(@"C:\Users\ghkkl\source\repos\ConsoleFM_Project\ConsoleFM_Project\Database\Buff.txt");
            StreamReader debuff = new StreamReader(@"C:\Users\ghkkl\source\repos\ConsoleFM_Project\ConsoleFM_Project\Database\DeBuff.txt");

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

            int buffNumb = randomBuff.Next(0, 56);
            int debuffNumb = randomDebuff.Next(0, 46);

            buffEnum = (Buff)buffNumb;
            debuffEnum = (Debuff)debuffNumb;

            string buffOutput = "";
            string debuffOutput = "";

            switch (buffEnum)
            {

                case Buff.STRENGTH_UP:
                    buffDictonary.TryGetValue(Buff.STRENGTH_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.STAMINA_UP:
                    buffDictonary.TryGetValue(Buff.STAMINA_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.JUMPING_UP:
                    buffDictonary.TryGetValue(Buff.JUMPING_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.SHOTPOWER_UP:
                    buffDictonary.TryGetValue(Buff.SHOTPOWER_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.REFLECTION_UP:
                    buffDictonary.TryGetValue(Buff.REFLECTION_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.AGILLITY_UP:
                    buffDictonary.TryGetValue(Buff.AGILLITY_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.SPRINT_UP:
                    buffDictonary.TryGetValue(Buff.SPRINT_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.ACCELERATION_UP:
                    buffDictonary.TryGetValue(Buff.ACCELERATION_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.PASSINGACCURACY_UP:
                    buffDictonary.TryGetValue(Buff.PASSINGACCURACY_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.HEADINGACCURACY_UP:
                    buffDictonary.TryGetValue(Buff.HEADINGACCURACY_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.SHOTACCURACY_UP:
                    buffDictonary.TryGetValue(Buff.SHOTACCURACY_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.DRIBBLE_UP:
                    buffDictonary.TryGetValue(Buff.DRIBBLE_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.TACKLE_UP:
                    buffDictonary.TryGetValue(Buff.TACKLE_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.SLIDINGTACKLE_UP:
                    buffDictonary.TryGetValue(Buff.SLIDINGTACKLE_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.MANTOMAN_UP:
                    buffDictonary.TryGetValue(Buff.MANTOMAN_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.POSITIONING_UP:
                    buffDictonary.TryGetValue(Buff.POSITIONING_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.VISION_UP:
                    buffDictonary.TryGetValue(Buff.VISION_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.GK_HANDLING_UP:
                    buffDictonary.TryGetValue(Buff.GK_HANDLING_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.GK_ONEONONE_UP:
                    buffDictonary.TryGetValue(Buff.GK_ONEONONE_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                case Buff.GK_DIVING_UP:
                    buffDictonary.TryGetValue(Buff.GK_DIVING_UP, out buffOutput);
                    Console.WriteLine(name + buffOutput);
                    break;

                default:
                    Console.WriteLine("버프가 적용되지 않았습니다.");
                    break;

            }

            switch (debuffEnum)
            {

                case Debuff.STRENGTH_DOWN:
                    debuffDictonary.TryGetValue(Debuff.STRENGTH_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.STAMINA_DOWN:
                    debuffDictonary.TryGetValue(Debuff.STAMINA_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.JUMPING_DOWN:
                    debuffDictonary.TryGetValue(Debuff.JUMPING_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.SHOTPOWER_DOWN:
                    debuffDictonary.TryGetValue(Debuff.SHOTPOWER_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.REFLECTION_DOWN:
                    debuffDictonary.TryGetValue(Debuff.REFLECTION_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.AGILLITY_DOWN:
                    debuffDictonary.TryGetValue(Debuff.AGILLITY_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.SPRINT_DOWN:
                    debuffDictonary.TryGetValue(Debuff.SPRINT_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.ACCELERATION_DOWN:
                    debuffDictonary.TryGetValue(Debuff.ACCELERATION_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.PASSINGACCURACY_DOWN:
                    debuffDictonary.TryGetValue(Debuff.PASSINGACCURACY_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.HEADINGACCURACY_DOWN:
                    debuffDictonary.TryGetValue(Debuff.HEADINGACCURACY_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.SHOTACCURACY_DOWN:
                    debuffDictonary.TryGetValue(Debuff.SHOTACCURACY_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.DRIBBLE_DOWN:
                    debuffDictonary.TryGetValue(Debuff.DRIBBLE_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.TACKLE_DOWN:
                    debuffDictonary.TryGetValue(Debuff.TACKLE_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.SLIDINGTACKLE_DOWN:
                    debuffDictonary.TryGetValue(Debuff.SLIDINGTACKLE_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.MANTOMAN_DOWN:
                    debuffDictonary.TryGetValue(Debuff.MANTOMAN_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.POSITIONING_DOWN:
                    debuffDictonary.TryGetValue(Debuff.POSITIONING_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.VISION_DOWN:
                    debuffDictonary.TryGetValue(Debuff.VISION_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.GK_HANDLING_DOWN:
                    debuffDictonary.TryGetValue(Debuff.GK_HANDLING_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.GK_ONEONONE_DOWN:
                    debuffDictonary.TryGetValue(Debuff.GK_ONEONONE_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                case Debuff.GK_DIVING_DOWN:
                    debuffDictonary.TryGetValue(Debuff.GK_DIVING_DOWN, out debuffOutput);
                    Console.WriteLine(name + debuffOutput);
                    break;

                default:
                    Console.WriteLine("디버프가 적용되지 않았습니다.");
                    break;

            }

        }

    }

    class Manager : Human
    {

        public Manager(string name, int age, string gender, int influence)
        {

            this.name = name;
            this.age = age;
            this.gender = gender;
            this.influence = influence;
            isCrowd = false; //false = 관중이 아님

        }

        public void ManagerInfo()    //입력 정보 한번에 출력하는 메소드
        {

            Console.WriteLine("Name: {0} | Age: {1} | Gender: {2} | Leadership: {3} | Position: Manager"
                             , name, age, gender, influence);

        }

    }

    class Coach : Human
    {

        public Coach(string name, int age, string gender, bool isCrowd, int influence)
        {

            this.name = name;
            this.age = age;
            this.gender = gender;
            this.influence = influence;
            this.isCrowd = isCrowd;

            isCrowd = false;

        }

        public override void SnackBar()
        {

            Random rand = new Random();           // 난수생성을 위한 Random 함수

            int expirationDate = rand.Next(0, 2); // 음식 유통기한 체크(0 = 유통기한이 지났다 , 1 = 유통기한 안지났다)

            int isUseSnackBar = rand.Next(0, 2);  // 매점 이용 여부 판단(0 = 이용 하지 않았다, 1 = 이용 했다)

            if (isUseSnackBar == 0)
            {

                Console.WriteLine("매점을 이용하지 않았습니다.");

            }

            else
            {

                if (expirationDate == 0)
                {

                    influence = 0;

                    Console.WriteLine("상한 음식을 먹어 속이 좋지 않습니다.");
                    Console.WriteLine("코치는 이번 경기에 결장 하였습니다.");

                }

                else
                {

                    influence += 10;

                    Console.WriteLine("음식을 섭취하여 기력이 회복 되었습니다.");
                    Console.WriteLine("코치의 지도력이 상승합니다.");

                }

            }

        }

        public void CoachInfo()    //입력 정보 한번에 출력하는 메소드
        {

            Console.WriteLine("Name: {0} | Age: {1} | Gender: {2} | Leadership: {3} | Position: Coach"
                             , name, age, gender, influence);

        }

    }

    class MedicalStaff : Human
    {

        int injury = 10;

        public MedicalStaff(string name, int age, string gender, bool isCrowd)
        {

            this.name = name;
            this.age = age;
            this.gender = gender;
            this.isCrowd = isCrowd;


            isCrowd = false;

        }

        public override void SnackBar()
        {

            Random rand = new Random();           // 난수생성을 위한 Random 함수

            int expirationDate = rand.Next(0, 2); // 음식 유통기한 체크(0 = 유통기한이 지났다 , 1 = 유통기한 안지났다)

            int isUseSnackBar = rand.Next(0, 2);  // 매점 이용 여부 판단(0 = 이용 하지 않았다, 1 = 이용 했다)

            if (isUseSnackBar == 0)
            {

                Console.WriteLine("매점을 이용하지 않았습니다.");

            }

            else
            {

                if (expirationDate == 0)
                {

                    injury += 25;

                    Console.WriteLine("상한 음식을 먹어 속이 좋지 않습니다.");
                    Console.WriteLine("의료진의 상태가 좋지 않아 선수들의 부상 위험이 올라갑니다.");

                }

                else
                {

                    injury = 5;

                    Console.WriteLine("질좋은 음식을 섭취하여 기력이 회복 되었습니다.");
                    Console.WriteLine("의료진의 컨디션이 좋아 선수들의 부상 위험이 감소 됩니다.\n");

                }

            }

        }

        public void MedicInfo()    //입력 정보 한번에 출력하는 메소드
        {

            Console.WriteLine("Name: {0} | Age: {1} | Gender: {2} | Injury % : {3}% | Position: Team Doctor"
                             , name, age, gender, injury);

        }

    }

    class Crowd : Human
    {

        Human crowd = new Human();

        int male;
        int female;

        public void VisitCrowds()
        {

            crowd.isCrowd = true;

            Random visited = new Random();

            int stadium = visited.Next(10000, 65000);

            for (int i = 0; i < stadium; i++)
            {

                Random rand = new Random(unchecked((int)DateTime.Now.Ticks) + i);

                int choiceGender = rand.Next(0, 3);

                if (choiceGender == 1 || choiceGender == 2) // 난수 1~2 는 남자
                {

                    male += 1;

                }

                else female += 1;                           // 난수 0 일 경우 여자

            }

            Console.WriteLine("찾아온 관객 성별 : 남 (" + male + ")" + "/ 여 (" + female + ")");

            Console.WriteLine("총 찾아온 관객 수 : " + stadium);

            if (stadium > 32500)        // 관중이 32500명(절반)이상 일 경우 영향력 최대
            {

                crowd.influence = 20;

                Console.WriteLine("경기장에 관중이 " + "" + stadium + "" + " 명이 모였습니다.");
                Console.WriteLine("경기 영향력이 " + "" + crowd.influence + "" + " 만큼 올라갑니다.");

            }

            else if (stadium < 32500 && stadium > 20000)   // 관중이 32500명(절반)이하 일 경우 영향력 중간
            {

                crowd.influence = 10;

                Console.WriteLine("경기장에 관중이 " + "" + stadium + "" + " 명이 모였습니다.");
                Console.WriteLine("경기 영향력이 " + "" + crowd.influence + "" + " 만큼 올라갑니다.");

            }

            else if (stadium < 20000) // 관중이 20000 명 이하라면 영향력 최소
            {

                crowd.influence = 5;

                Console.WriteLine("경기장에 관중이 " + "" + stadium + "" + " 명이 모였습니다.");
                Console.WriteLine("경기 영향력이 " + "" + crowd.influence + "" + " 만큼 올라갑니다.");

            }

        }

    }

    class Program
    {

        static void Menu() //메인 메뉴 구성
        {

            Console.WriteLine("====================");
            Console.WriteLine("=====          =====");
            Console.WriteLine("===== MainMenu =====");
            Console.WriteLine("=====          =====");
            Console.WriteLine("===== 1. Start =====");
            Console.WriteLine("=====          =====");
            Console.WriteLine("===== 2. Option ====");
            Console.WriteLine("=====          =====");
            Console.WriteLine("===== 3. Exit  =====");
            Console.WriteLine("=====          =====");
            Console.WriteLine("====================");

        }

        static void Main()
        {

            bool isBool = true;

            while (isBool) //while 문을 써서 계속 메뉴 돌아다닐 수 있게
            {

                Menu(); //메인 메뉴 호출

                Console.Write("Select Menu: ");

                string select = Console.ReadLine();

                switch (select)
                {

                    case "1":   //1 입력 시 게임 입장 전 선수 등록 등의 메뉴를 출력
                        Select1(); // 선수 등록하는 메소드 호출
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("미구현");
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("잘못된 입력 입니다\n");
                        break;

                }

            }

        }

        ////Console.Read(); //대기

        static void Select1()
        {

            Console.Clear();

            bool check = true; //bool 타입 check 변수 선언 

            Console.WriteLine("=========================");
            Console.WriteLine("=====               =====");
            Console.WriteLine("===== Game Setting  =====");
            Console.WriteLine("=====               =====");
            Console.WriteLine("= 1. RegisteringPlayers =");
            Console.WriteLine("=====               =====");
            Console.WriteLine("= 2. Registering Staffs =");
            Console.WriteLine("=====               =====");
            Console.WriteLine("===== 3. Start Game =====");
            Console.WriteLine("=====               =====");
            Console.WriteLine("== 4. Return Main Menu ==");
            Console.WriteLine("=====               =====");
            Console.WriteLine("=========================");

            while (check) //check 변수가 true 인 동안 계속해서 반복
            {

                Console.Write("Select Menu: ");

                string select = Console.ReadLine(); //문자열 string 변수는 입력받는 값으로 초기화 된다.

                switch (select)    //switch문 select 변수가 받는 값에 따라
                {

                    case "1":                                           //1 입력시 출력 
                        Console.Clear();
                        Console.WriteLine("선수 정보를 입력 합니다.\n");
                        InputPlayerInfo();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("감독을 설정 합니다");
                        Select2();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("미구현\n");
                        Console.WriteLine("=========================");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("===== Game Setting  =====");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("= 1. RegisteringPlayers =");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("= 2. Registering Staffs =");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("===== 3. Start Game =====");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("== 4. Return Main Menu ==");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("=========================");
                        break;

                    case "4":           //3 입력 시 해당 while 문을 빠져나가고 Main메소드로 돌아가게됨
                        Console.Clear();
                        check = false;
                        Main();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력 입니다.\n");
                        Console.WriteLine("=========================");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("===== Game Setting  =====");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("= 1. RegisteringPlayers =");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("= 2. Registering Staffs =");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("===== 3. Start Game =====");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("== 4. Return Main Menu ==");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("=========================");
                        break;

                }
            }

        }

        static void Select2()
        {

            Console.Clear();

            bool check = true;

            Console.WriteLine("=========================");
            Console.WriteLine("=====               =====");
            Console.WriteLine("== Registering Staffs  ==");
            Console.WriteLine("=====               =====");
            Console.WriteLine("= 1. RegisteringManager =");
            Console.WriteLine("=====               =====");
            Console.WriteLine("= 2. Registering Coach  =");
            Console.WriteLine("=====               =====");
            Console.WriteLine("= 3. RegisteringMedical =");
            Console.WriteLine("=====     Staff     =====");
            Console.WriteLine("=====               =====");
            Console.WriteLine("= 4.       Back     =====");
            Console.WriteLine("=====               =====");
            Console.WriteLine("=========================");



            while (check)
            {

                Console.Write("Select Menu: ");

                string select = Console.ReadLine();

                switch (select)
                {

                    case "1":
                        Console.Clear();
                        Console.WriteLine("감독 정보를 입력 합니다.\n");
                        InputManagerInfo();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("코치 정보를 입력 합니다.\n");
                        InputCoachInfo();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("팀 닥터의 정보를 입력 합니다.\n");
                        InputMedicInfo();
                        break;

                    case "4":
                        Console.Clear();
                        check = false;
                        Select1();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력 입니다.\n");
                        Console.WriteLine("=========================");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("===== Game Setting  =====");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("= 1. RegisteringPlayers =");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("= 2. Registering Staffs =");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("===== 3. Start Game =====");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("== 4. Return Main Menu ==");
                        Console.WriteLine("=====               =====");
                        Console.WriteLine("=========================");
                        break;

                }

            }

        }

        static void InputPlayerInfo()
        {

            bool check = true;

            while (check)
            {

                Console.Write("Name: ");
                string name = Console.ReadLine();               //이름 입력 부분
                Console.WriteLine("");                          //한 칸 띄우기

                Console.Write("Back Number: ");
                int backNumb = int.Parse(Console.ReadLine());   //등번호 입력 부분 (Console.ReadLine 이 스트링 형 만 받을 수 있어서 형변환 필수)
                Console.WriteLine("");

                Console.Write("Position: ");
                string position = Console.ReadLine();           //포지션 입력 부분
                Console.WriteLine("");

                Console.Write("Prefered Foot: ");
                string prefFoot = Console.ReadLine();           //선호하는 발 입력 부분
                Console.WriteLine("");

                Console.Write("Weak Foot: ");
                int weakFoot = int.Parse(Console.ReadLine());   //약한 발은 사용 빈도에 따라 1~5 사이라서 인트형
                Console.WriteLine("");

                Player player = new Player(name, backNumb, position, prefFoot, weakFoot);   //객체 생성 후 매개변수는 사용자 입력받은 값을 받는다.

                Console.Clear();

                Console.WriteLine("등록된 선수 목록 \n");

                player.PlayerInfo();

                player.SnackBar();

                player.BuffAndDebuff();

                Console.WriteLine("등록을 종료 하려면 (N/n)을 입력해 주세요.\n");
                Console.WriteLine("입력을 계속하는 경우 아무키나 눌러주세요.\n");

                string key = Console.ReadLine();

                if (key == "N" || key == "n")
                {

                    check = false;

                    Select1();

                }

            }

        }

        static void InputManagerInfo()
        {

            Console.Write("Name: ");
            string name = Console.ReadLine();               //이름 입력 부분
            Console.WriteLine("");                          //한 칸 띄우기

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.WriteLine("");

            //Console.Write("관중이 아닙니다.");
            //bool isCrowd = false;       
            //Console.WriteLine("");

            Random rand = new Random();
            int influence = rand.Next(0, 21);
            Console.Write("leadership: " + influence); //경기 영향력은 랜덤으로
            Console.WriteLine("\n");

            Manager manager = new Manager(name, age, gender, influence);   //객체 생성 후 매개변수는 사용자 입력받은 값을 받는다.
            Console.WriteLine("등록된 감독 정보 \n");
            manager.ManagerInfo();
            Console.WriteLine("");

            Console.WriteLine("감독 등록을 종료 하시려면 아무 키나 눌러 주세요.");
            Console.Read();

            Select1();

            //Console.Clear();

        }

        static void InputCoachInfo()
        {

            Console.Write("Name: ");
            string name = Console.ReadLine();               
            Console.WriteLine("");                          

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.WriteLine("");

            Random rand = new Random();
            int influence = rand.Next(0, 21);
            Console.Write("leadership: " + influence); //경기 영향력은 랜덤으로
            Console.WriteLine("\n");

            Coach coach = new Coach(name, age, gender, true, influence);   //객체 생성 후 매개변수는 사용자 입력받은 값을 받는다.

            Console.WriteLine("등록된 수석코치 정보 \n");

            coach.CoachInfo();

            coach.SnackBar();

            Console.WriteLine("");

            Console.WriteLine("등록을 종료 하시려면 아무 키나 눌러 주세요.");
            Console.Read();

            Select1();

        }

        static void InputMedicInfo()
        {

            Console.Write("Name: ");
            string name = Console.ReadLine();               //이름 입력 부분
            Console.WriteLine("");                          //한 칸 띄우기

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.WriteLine("");

            MedicalStaff medic = new MedicalStaff(name, age, gender, true);   //객체 생성 후 매개변수는 사용자 입력받은 값을 받는다.

            medic.SnackBar();

            Console.WriteLine("등록된 수석코치 정보 \n");

            medic.MedicInfo();

            Console.WriteLine("");

            Console.WriteLine("등록을 종료 하시려면 아무 키나 눌러 주세요.");
            Console.Read();

            Select1();

        }



    }

}


