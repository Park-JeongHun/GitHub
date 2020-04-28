using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ConsoleFM_Project
{

    class Program
    {

        static List<Player> playerList = new List<Player>();
        static List<Player> subPlayerList = new List<Player>();

        static List<string> nameList = new List<string>();
        static List<int>    numbList = new List<int>();
        static List<string> posiList = new List<string>();
        static List<string> footList = new List<string>();
        static List<int>    weakList = new List<int>();
        static List<int>    overallList = new List<int>();

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
                        GameSetting();
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

            string key;

            Random rand = new Random();

            int overall = 0;

            while (check)
            {

                int strength = rand.Next(10, 21);
                int stamina = rand.Next(10, 21);
                int jump = rand.Next(10, 21);
                int shotPower = rand.Next(10, 21);
                int reaction = rand.Next(10, 21);
                int agility = rand.Next(10, 21);
                int sprint = rand.Next(10, 21);
                int accel = rand.Next(10, 21);
                int passAc = rand.Next(10, 21);
                int headAc = rand.Next(10, 21);
                int shotAc = rand.Next(10, 21);
                int dribble = rand.Next(10, 21);
                int tackle = rand.Next(10, 21);
                int sliding = rand.Next(10, 21);
                int mantoman = rand.Next(10, 21);
                int positioning = rand.Next(10, 21);
                int vision = rand.Next(10, 21);
                int gk_handle = rand.Next(10, 21);
                int gk_onetoone = rand.Next(10, 21);
                int gk_diving = rand.Next(10, 21);

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

                if (position == "FW") overall =
                (strength + shotPower + reaction + agility + sprint + accel + passAc + headAc + shotAc + dribble + positioning) / 11;

                if (position == "MF") overall =
                (stamina + reaction + agility + passAc + dribble + tackle + vision) / 7;

                if (position == "DF") overall =
                (strength + jump + reaction + agility + sprint + passAc + headAc + tackle + sliding + mantoman + positioning) / 11;

                if (position == "GK") overall =
                (gk_handle + gk_onetoone + gk_diving + passAc + jump + strength + positioning) / 7;

                if (playerList.Count < 11)
                {

                    Player player = new Player(name, backNumb, position, prefFoot, weakFoot, overall);   //객체 생성 후 매개변수는 사용자 입력받은 값을 받는다.

                    playerList.Add(player);
                    nameList.Add(name);
                    numbList.Add(backNumb);
                    posiList.Add(position);
                    footList.Add(prefFoot);
                    weakList.Add(weakFoot);
                    overallList.Add(overall);

                    Console.Clear();

                    Console.WriteLine("등록된 선수 목록 \n");

                    player.PlayerInfo();

                    player.SnackBar();

                    player.BuffAndDebuff();

                }

                else if(subPlayerList.Count < 7)
                {

                    Player subPlayer = new Player(name, backNumb, position, prefFoot, weakFoot, overall);   //객체 생성 후 매개변수는 사용자 입력받은 값을 받는다.

                    subPlayerList.Add(subPlayer);
                    nameList.Add(name);
                    numbList.Add(backNumb);
                    posiList.Add(position);
                    footList.Add(prefFoot);
                    weakList.Add(weakFoot);
                    overallList.Add(overall);

                    Console.Clear();

                    Console.WriteLine("등록된 선수 목록 \n");

                    subPlayer.PlayerInfo();

                    subPlayer.SnackBar();

                    subPlayer.BuffAndDebuff();

                }

                else
                {

                    Console.WriteLine("등록 제한을 초과하였습니다. (주전 11명 , 후보 7명)");

                    Console.Read();

                    check = false;

                    Select1();

                }


                Console.WriteLine("등록을 종료 하려면 (N/n)을 입력해 주세요.\n");
                Console.WriteLine("입력을 계속하는 경우 아무키나 눌러주세요.\n");

                key = Console.ReadLine();

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

        static void GameSetting()
        {

            Console.WriteLine("=========================");
            Console.WriteLine("=====               =====");
            Console.WriteLine("===== Game Setting  =====");
            Console.WriteLine("=====               =====");
            Console.WriteLine("===== 1. Next Match =====");
            Console.WriteLine("=====               =====");
            Console.WriteLine("==== 2. My Club Info ====");
            Console.WriteLine("=====               =====");
            Console.WriteLine("=====    3. Back    =====");
            Console.WriteLine("=====               =====");
            Console.WriteLine("== 4. Return Main Menu ==");
            Console.WriteLine("=====               =====");
            Console.WriteLine("=========================");

        }

    }

}


