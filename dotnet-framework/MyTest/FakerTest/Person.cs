using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace FakerTest
{
    class Person
    {
        public Person()
        {
            this.Name = Faker.Name.GetName();
            this.Address= Faker.Address.GetCity();
            this.PhoneNum = Faker.PhoneNumber.GetPhoneNumber();
            this.Education = Faker.Education.GetDegree();
            this.Company = Faker.Company.GetName();
            this.CriditcardNum = Faker.CreditCard.CreditCardNumber("visa");
        }
        
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        public string Education { get; set; }
        public string Company { get; set; }
        public string CriditcardNum { get; set; }

        public override string ToString()
        {
            return string.Format("Name:{0} & Address:{1} & PhoneNum:{2} & Education:{3} & Company:{4} & CriditcardNum:{5}", Name, Address, PhoneNum, Education, Company, CriditcardNum);
        }
    }
}
