using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_14_1
{
    public class Test
    {
        public static void NotMain()
        {
            var pupil = new Pupil();
            //var a = pupil.Str1;
            //var b = pupil.Str2;
            //var c = pupil.str3;
            //var d = pupil.str4;
            var e = pupil.Str5;

        }

        
    }

    public class Pupil
    {
        readonly string Str1 = "str1";
        const string Str2 = "str2";
        private string str3 = "str3";
        private readonly string str4 = "str4";
        public readonly string Str5 = "str5";
        public Pupil()
        {
            Str1 = "sstr1";
            //Str2 = "sstr2";
            str3 = "sstr3";
            str4 = "sstr4";
            Str5 = "sstr5";

        }

        public void ChangeFieldsInPublicMethod() 
        {
            //Str1 = "ssstr1";
            //Str2 = "ssstr2";
            str3 = "ssstr3";
            //str4 = "ssstr4";
            //Str5 = "ssstr5";
        }

        private void ChangeFieldsInPrivateMethod()
        {
            //Str1 = "ssstr1";
            //Str2 = "ssstr2";
            str3 = "ssstr3";
            //str4 = "ssstr4";
            //Str5 = "ssstr5";
        }
        public void DoSomething() 
        {
            //Str1 = "ssstr1"; // It doesn't work
            //Str2 = "ssstr2"; // It doesn't work
        }

        //string Str3
        //{
        //    get { return Str3; }
        //    set { Str3 = value; }
        //}
    }
}
