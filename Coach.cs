
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFM_Project
{
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

}
