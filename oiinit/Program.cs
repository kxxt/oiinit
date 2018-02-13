using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace oiinit
{
    class Program
    {
        static Program()
        {
            mainT=new string[4]{"","","",""};
            CppT=new string[3] { "", "", "" };
            ioT=new []{"","","","","","","","",""};
            try
            {
                env = Environment.CurrentDirectory+"\\";
                bin = env + "oiinit_bin\\";
                defineT = File.ReadAllText(bin + "define.template.cpp");
                ioT = File.ReadAllLines(bin + "io.template.cpp");
                includeT = File.ReadAllText(bin + "include.template.cpp");
                mainT[0]= File.ReadAllText(bin+"main.template.cpp");
                
                batT = File.ReadAllText(bin + "template.bat.dat");
                CppT[0] = File.ReadAllText(bin+"template.template.cpp");
            }
            catch (Exception e)
            {
                OnError("File Reading Failed!",RsWork.Functions.Log.Logger.GetExceptionInfo(e),"Repair the application and try again.\r\nGithub:https://github.com/kxxt/oiinit\r\n");
#if DEBUG
                throw;
#endif
            }
        }

        static void ProcessSgn(string sgn)
        {
            for (int i=0;i<ioT.Length;i++)
            {
                ioT[i]=ioT[i].Replace("#REPLACESIGN#", sgn);
            }
            defineT=defineT.Replace("#REPLACESIGN#", sgn);
            includeT= includeT.Replace("#REPLACESIGN#", sgn);
            batT=batT.Replace("#REPLACESIGN#", sgn);
            
            
            mainT[0] = mainT[0].Replace("#REPLACESIGN#", sgn);
            
        }

        static void Work(string sgn,string use, string create)
        {
            
            ProcessSgn(sgn);
            CppT[0] = CppT[0].Replace("#DEFINATIONS_REPLACE_BLOCK#",defineT);
            //0:sgn.cpp;1:_sgn.cpp;2:mkdata.cpp;
            mainT[1] = mainT[0].Replace("#IO_REPLACE_BLOCK#",ioT[4]+"\r\n\t"+ioT[5]);
            mainT[2] = mainT[0].Replace("#IO_REPLACE_BLOCK#", ioT[7]);//TODO:
            mainT[0] = mainT[0].Replace("#IO_REPLACE_BLOCK#", ioT[1] +"\r\n\t"+ ioT[2]);
            if (use.Trim() == "1")
            {
                CppT[0] = CppT[0].Replace("#INCLUDE_REPLACE_BLOCK#", "#include<bits/stdc++.h>\r\n");
            }
            else
            {
                CppT[0] = CppT[0].Replace("#INCLUDE_REPLACE_BLOCK#",includeT);
            }

            CppT[1] = CppT[0].Replace("#MAIN_BLOCK#", mainT[1]);
            CppT[2] = CppT[0].Replace("#MAIN_BLOCK#", mainT[2]);
            CppT[0] = CppT[0].Replace("#MAIN_BLOCK#", mainT[0]);
            string workdir = env+sgn+"\\";
            Directory.CreateDirectory(env + sgn);
            File.Create(workdir+ sgn + ".cpp").Close();
            File.WriteAllText(workdir+sgn+".cpp",CppT[0]);
            if (create.Trim() == "1")
            {
                File.Create(workdir + "_" + sgn + ".cpp").Close();
                File.Create(workdir + "mkdata.cpp").Close();
                File.Create(workdir+"cpr.bat").Close();
                File.WriteAllText(workdir + "_" + sgn + ".cpp",CppT[1]);
                File.WriteAllText(workdir + "mkdata.cpp",CppT[2]);
                File.WriteAllText(workdir+"cpr.bat",batT);
            }
            

            
            


        }
        private static string env = "!NOT INITED!";
        private static string bin = "!NOT INITED!";
        private static string defineT = "!NOT INITED!";
        private static string[] ioT;
        private static string[] mainT;
        private static string includeT = "!NOT INITED!";
        private static string[] CppT;
        private static string batT="!NOT INITED!";
        //static readonly string errval= "The value of {0} cant be \"{1}\".";
        static void Output(ConsoleColor b, ConsoleColor f, string s)
        {
            Console.BackgroundColor = b;
            Console.ForegroundColor = f;
            Console.Write(s);
            Console.ResetColor();
        }
        static void OnError(string title,string info,string advice=null)
        {
            Output(ConsoleColor.White,ConsoleColor.Red,"ERROR!");
            Output(ConsoleColor.Black,ConsoleColor.White,title+"\r\n");
            Output(ConsoleColor.Red,ConsoleColor.White,info+"\r\n");
            if (!String.IsNullOrEmpty(advice))
            {
                Output(ConsoleColor.DarkBlue,ConsoleColor.Yellow,advice+"\r\n");
            }
        }
        static void Main(string[] args)
        {
			ShowSplash();
            if (args.Length ==0)
            {
                ShowHelp();
                return;
            }
            else
            {
                if (args[0] == "oiinit_bin")
                {
                    OnError("Error","The path has been used by this application!\r\nAre you trying to Hack this app?","Try another path.\r\nIf you have anything to tell me,new an issue on https://www.github.com/kxxt/oiinit");
                    return;
                }
                try
                {
                    Output(ConsoleColor.Black,ConsoleColor.Cyan,"Please wait,we are busying performing your command.\r\n");

                    #region VERSION1.01

                    /*
                    Console.WriteLine("Please wait,we are busying performing your command.");
                    
                    //Console.WriteLine(env);
                    Directory.CreateDirectory(env + "\\" + args[0]);
                    string name = env + "\\" + args[0] + '\\' + args[0] + ".cpp";
                    File.Create(name).Close();
                    string freopen1 = "freopen(\"" + args[0] + ".in\",\"r\",stdin);";
                    string freopen2 = "freopen(\"" + args[0] + ".out\",\"w\",stdout);";
                    switch (args[1])
                    {
                        case "1":

                            File.WriteAllText(name,
                                "#include<bits\\stdc++.h>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\nint main()\r\n{\r\n\t" +
                                freopen1 + "\r\n\t" + freopen2 + "\r\n}");
                            break;
                        case "0":
                            File.WriteAllText(name,
                                "#include<cstdlib>\r\n#include<cmath>\r\n#include<algorithm>\r\n#include<bitset>\r\n#include<cstdio>\r\n#include<cstring>\r\n#include<ctime>\r\n#include<deque>\r\n#include<iomanip>\r\n#include<iostream>\r\n#include<list>\r\n#include<map>\r\n#include<queue>\r\n#include<set>\r\n#include<stack>\r\n#include<string>\r\n#include<vector>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\nint main()\r\n{\r\n\t" +
                                freopen1 + "\r\n\t" + freopen2 + "\r\n}");
                            break;
                        default: throw new ArgumentException(string.Format(errval, "arg2", args[2]), nameof(args) + "[1]");
                    }

                    if (args.Length > 2)
                    {
                        string _freopen1 = "freopen(\"" + args[0] + ".in\",\"r\",stdin);";
                        string _freopen2 = "freopen(\"_" + args[0] + ".out\",\"w\",stdout);";

                        switch (args[2])
                        {
                            case "0":
                                break;
                            case "1":
                                string tmp = env + "\\" + args[0] + "\\";
                                File.Create(tmp + "mkdata.cpp").Close();
                                File.Create(tmp + "_" + args[0] + ".cpp").Close();
                                File.Create(tmp + "cp.bat").Close();
                                string bat = File.ReadAllText("template.bat.dat");
                                bat = bat.Replace("#REPLACESIGN#", args[0]);
                                File.WriteAllText(tmp + "cp.bat", bat);
                                switch (args[1])
                                {
                                    case "0":
                                        File.WriteAllText(tmp + "mkdata.cpp",
                                            "#include<bits\\stdc++.h>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\nint main()\r\n{\r\n\t" +
                                            "freopen(\"" + args[0] + ".in\",\"w\",stdout);" + "\r\n\t\r\n}");
                                        File.WriteAllText(tmp + "_" + args[0] + ".cpp",
                                            "#include<bits\\stdc++.h>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\nint main()\r\n{\r\n\t" +
                                            _freopen1 + "\r\n" + _freopen2 + "\r\n\t\r\n}");
                                        break;
                                    case "1":
                                        File.WriteAllText(tmp + "mkdata.cpp",
                                            "#include<cstdlib>\r\n#include<cmath>\r\n#include<algorithm>\r\n#include<bitset>\r\n#include<cstdio>\r\n#include<cstring>\r\n#include<ctime>\r\n#include<deque>\r\n#include<iomanip>\r\n#include<iostream>\r\n#include<list>\r\n#include<map>\r\n#include<queue>\r\n#include<set>\r\n#include<stack>\r\n#include<string>\r\n#include<vector>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\nint main()\r\n{\r\n\t" +
                                            "freopen(\"" + args[0] + ".in\",\"w\",stdout);" + "\r\n\t\r\n}");
                                        File.WriteAllText(tmp + "_" + args[0] + ".cpp",
                                            "#include<cstdlib>\r\n#include<cmath>\r\n#include<algorithm>\r\n#include<bitset>\r\n#include<cstdio>\r\n#include<cstring>\r\n#include<ctime>\r\n#include<deque>\r\n#include<iomanip>\r\n#include<iostream>\r\n#include<list>\r\n#include<map>\r\n#include<queue>\r\n#include<set>\r\n#include<stack>\r\n#include<string>\r\n#include<vector>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\nint main()\r\n{\r\n\t" +
                                            _freopen1 + "\r\n\t" + _freopen2 + "\r\n\t\r\n}");
                                        break;
                                    default: throw new ArgumentException(string.Format(errval,"arg1",args[1]), nameof(args) + "[1]");
                                }


                                break;
                            default: throw new ArgumentException(string.Format(errval, "arg2", args[2]), nameof(args)+"[2]");

                        }
                    }*/

                    #endregion

                    switch (args.Length)
                    {
                        case 1:
                            Work(args[0], "", "");
                            break;
                        case 2:
                            Work(args[0], args[1], "");
                            break;
                        case 3:
                            Work(args[0], args[1], args[2]);
                            break;
                        default:
                            Output(ConsoleColor.Black, ConsoleColor.Yellow,
                                "WARNING:Args are more than the excepted!\r\n");
                            goto case 3;
                    }

                    Output(ConsoleColor.Black, ConsoleColor.Green, "Process Succeed!\r\n");
                }
                catch
                {
                    throw;
                }

                /*                catch (Exception ce)
                                {
                                    OnError(ce.Message,RsWork.Functions.Log.Logger.GetExceptionInfo(ce),"Advice:Check the arguments and try again.");
                #if DEBUG
                                throw;
                #endif
                                }*/
            }
        }
		private static void ShowSplash()
		{
			Output(ConsoleColor.Black,ConsoleColor.DarkBlue, "************************************************************************\r\n");
		    Output(ConsoleColor.Black, ConsoleColor.DarkBlue,"* (C)Copyright Believers in Science Studio 2018  (ver 2.00)            *\r\n");
		    Output(ConsoleColor.Black, ConsoleColor.Blue,    "* This is a freeware,you can copy,share or modify it freely            *\r\n" +
							                                 "* under the LGPL Licence.You can modify the templates in dir:oiinit_bin*\r\n");
		    Output(ConsoleColor.Black, ConsoleColor.DarkCyan,"* GitHub:https://github.com/kxxt/oiinit/                               *\r\n" +
							                                 "* If you have anything to tell me,new an issue on github.              *\r\n");
		    Output(ConsoleColor.Black,ConsoleColor.Cyan,     "* Contact author:e-mail:renpengfei@rswork.heliohost.org                *\r\n");
		    Output(ConsoleColor.Black,ConsoleColor.Cyan,     "************************************************************************\r\n");
		}

		private static void ShowHelp()
        {
            Console.WriteLine("arg0:Input your Project Name.");
            Console.WriteLine("arg1:Use stdc++.h: 1 for using,others for not using.");
            Console.WriteLine("arg2[optional]:Create a batch tool to compare results.\r\n" +
                              "\t\t1 for using,others for not using(default).");        
        }
    }
}
