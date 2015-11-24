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
            string s1 = "350000, � ���������, �� ��������, �. 73, ����. �, ��. 11";
            string s2 = "188660, ������������� ���, ������������ �-�, ����� �, �� ���������, �. 30, ��. 25";

            MatchsMaker match=new MatchsMaker(s1, s2) ;
			Trace.WriteLine(match.Score) ;			
		}
	}
}
