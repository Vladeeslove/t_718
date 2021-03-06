﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WntifDB
{
    class interpret
    {
        List<string> ListMainWords=new List<string>();
        Authorization AutoUser;
        public string command = null;
        string where = null;
        string from = null;
        public interpret(Authorization AutoUser)
        {
            this.AutoUser = AutoUser;
            bootList();
            command = ReadRequest();
        }
        private void bootList()
        {
            ListMainWords.Add("CREATE");
            ListMainWords.Add("TABLE");
            ListMainWords.Add("DATABASE");
            ListMainWords.Add("SELECT");
            ListMainWords.Add("UPDATE");
            ListMainWords.Add("DELETE");
            ListMainWords.Add("INNER");
            ListMainWords.Add("FROM");
            ListMainWords.Add("WHERE");
            ListMainWords.Add("IN");
            ListMainWords.Add("EXIT");
        }
        private string ReadRequest()
        {
            char prev = '0';string temp;
            Console.Write("\n@WntifDB>");//new interation application
            if (AutoUser.Name != null)
            {
                Console.Write(AutoUser.Name + ">Job>");
                if (AutoUser.NameDB != null)
                    Console.Write(AutoUser.NameDB + ">");
            }
            
            string TempSTR = "";
            ConsoleKeyInfo keyinfo = Console.ReadKey(true);
            while (keyinfo.Key != ConsoleKey.Enter)
            {
                if (keyinfo.Key == ConsoleKey.Spacebar)
                {
                    
                    if (TempSTR.IndexOf(" ") == -1)
                        temp = TempSTR;
                    else
                     temp = TempSTR.Substring(TempSTR.LastIndexOf(" ")+1);
                    if (ListMainWords.Contains(temp))
                    {
                        OutCommandWord(temp);
                        temp = "";
                    }
                }
                if (keyinfo.Key != ConsoleKey.Backspace)
                {
                    
                    Console.Write(Char.ToUpper(keyinfo.KeyChar));
                 
                        TempSTR += Char.ToUpper(keyinfo.KeyChar);
                }
                else if (keyinfo.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(TempSTR))
                    {
                        TempSTR = TempSTR.Substring(0, TempSTR.Length - 1);
                        int position = Console.CursorLeft;
                        Console.SetCursorPosition(position - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(position - 1, Console.CursorTop);
                        if (prev == ' ')
                        {
                           // Console.WriteLine("|срванивается эта дичь типа /" + TempSTR.IndexOf(" ") + "|");
                            if (TempSTR.IndexOf(" ") == -1)
                                temp = TempSTR;
                            else
                                temp = TempSTR.Substring(TempSTR.LastIndexOf(" ") + 1);
                            DamageCommandWord(temp);
                            temp = "";
                        }
                    }
                }
                if(keyinfo.Key!=ConsoleKey.Backspace)
                prev = keyinfo.KeyChar;
                keyinfo = Console.ReadKey(true);
            }
            return TempSTR;
        }
        private void OutCommandWord(string word)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            int position = Console.CursorLeft;
           
            for (int i = 0; i < word.Length; i++)
            {
                Console.SetCursorPosition(position - word.Length, Console.CursorTop);
                Console.Write(" ");
                Console.SetCursorPosition(position - word.Length, Console.CursorTop);
            }
            Console.Write(word);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void DamageCommandWord(string word)
        {
            int position = Console.CursorLeft;
            for (int i = 0; i < word.Length; i++)
            {
                Console.SetCursorPosition(position - word.Length, Console.CursorTop);
                Console.Write(" ");
                Console.SetCursorPosition(position - word.Length, Console.CursorTop);
            }
            Console.Write(word);
        }
    }
}
