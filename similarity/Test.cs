using System;
using System.Diagnostics;
using System.Text.RegularExpressions ;

namespace WordsMatching
{
	class Test
	{
		[STAThread]
		static void Main(string[] args)
		{
			Test t = new Test();
		}

		public Test()
		{
            string s1 = "350000, г краснодар, ул Гагарина, д. 73, корп. а, кв. 11";
            string s2 = "188660, Ленинградская обл, Всеволожский р-н, Бугры п, ул Шоссейная, д. 30, кв. 25";

            MatchsMaker match=new MatchsMaker(s1, s2) ;
			Trace.WriteLine(match.Score) ;			
		}
	}
}
