using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace oiinit
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                ShowHelp();
                return;
            }
            else
            {
                
                string env = Environment.CurrentDirectory;
                Console.WriteLine(env);
                Directory.CreateDirectory(env+"\\"+args[0]);
                string name = env+"\\"+args[0] + '\\' + args[0] + ".cpp";
                File.Create(name).Close();
                string freopen1 = "freopen(\"" + args[0] + ".in\",\"r\",stdin);";
                string freopen2 = "freopen(\"" + args[0] + ".out\",\"w\",stdout);";
                switch (args[1])
                {
                    case "1":
                        
                        File.WriteAllText(name, "#include<bits\\stdc++.h>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\n\r\nint main()\r\n{"+freopen1+"\r\n"+freopen2+"\r\n\t\r\n}");
                        break;
                    case "0":
                        File.WriteAllText(name, "#include<cstdlib>\r\n#include<cmath>\r\n#include<array>\r\n#include<algorithm>\r\n#include<bitset>\r\n#include<cstdio>\r\n#include<cstring>\r\n#include<ctime>\r\n#include<deque>\r\n#include<iomanip>\r\n#include<iostream>\r\n#include<list>\r\n#include<map>\r\n#include<queue>\r\n#include<set>\r\n#include<stack>\r\n#include<string>\r\n#include<vector>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\n\r\nint main()\r\n{" + freopen1 + "\r\n" + freopen2 + "\r\n\t\r\n}");
                        break;
                    default: goto case "0";
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
                            switch (args[1])
                            {
                                case "0":
                                    File.WriteAllText(tmp+"mkdata.cpp", "#include<bits\\stdc++.h>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\n\r\nint main()\r\n{"+ "freopen(\"" + args[0] + ".in\",\"w\",stdout);" +"\r\n\t\r\n}");
                                    break;
                                case "1":
                                    File.WriteAllText(tmp+"mkdata.cpp", "#include<cstdlib>\r\n#include<cmath>\r\n#include<array>\r\n#include<algorithm>\r\n#include<bitset>\r\n#include<cstdio>\r\n#include<cstring>\r\n#include<ctime>\r\n#include<deque>\r\n#include<iomanip>\r\n#include<iostream>\r\n#include<list>\r\n#include<map>\r\n#include<queue>\r\n#include<set>\r\n#include<stack>\r\n#include<string>\r\n#include<vector>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\n\r\nint main()\r\n{" + "freopen(\"" + args[0] + ".in\",\"w\",stdout);" + "\r\n\t\r\n}");
                                    break;
                                default: goto case "0";
                            }
                            File.Create(tmp + "_"+args[0]+".cpp").Close();
                            switch (args[1])
                            {
                                case "1":
                                    File.WriteAllText(tmp + "_" + args[0] + ".cpp", "#include<bits\\stdc++.h>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\n\r\nint main()\r\n{"+_freopen1+"\r\n"+_freopen2+"\r\n\t\r\n}");
                                    break;
                                case "0":
                                    File.WriteAllText(tmp + "_" + args[0] + ".cpp", "#include<cstdlib>\r\n#include<cmath>\r\n#include<array>\r\n#include<algorithm>\r\n#include<bitset>\r\n#include<cstdio>\r\n#include<cstring>\r\n#include<ctime>\r\n#include<deque>\r\n#include<iomanip>\r\n#include<iostream>\r\n#include<list>\r\n#include<map>\r\n#include<queue>\r\n#include<set>\r\n#include<stack>\r\n#include<string>\r\n#include<vector>\r\nusing namespace std;\r\n#define inf 2147483647\r\n#define For(i,j,k) for(int i=j;i<=k;i++)\r\n#define Dor(i,j,k) for(int i=j;i>=k;i--)\r\n\r\n\r\nint main()\r\n{" + _freopen1 + "\r\n" + _freopen2 + "\r\n\t\r\n}");
                                    break;
                                default: goto case "0";
                            }
                            break;
                        default: goto case "0";

                    }
                }
                
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("********************************************************");
            Console.WriteLine("(C)Copyright Believers in Science Studio 2018  (ver 1.00)");
            Console.WriteLine("This is a freeware,you can copy,share or modify it freely\r\n" +
                              "under LGPL Licence.");
            Console.WriteLine("********************************************************");
            Console.WriteLine("arg0:Set Project Name.");
            Console.WriteLine("arg1:Use stdc++.h: 1 for using,0 for not using.");
            Console.WriteLine("arg2[optional]:Create a batch tool to Compare results.\r\n" +
                              "\t\t\t1 for using,0 for not using.0 is the default value.");
            
            
        }
    }
}
