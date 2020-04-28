using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFM_Project
{
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

}
