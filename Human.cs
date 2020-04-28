using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFM_Project
{

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

}
