using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFM_Project
{

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

}
