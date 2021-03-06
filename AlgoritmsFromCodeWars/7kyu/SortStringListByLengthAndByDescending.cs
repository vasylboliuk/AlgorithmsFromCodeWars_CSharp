﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsFromCodeWars._7kyu
{
    public class SortStringListByLengthAndByDescending
    {
        /// <summary>
        /// Suzuki needs help lining up his students!
        /// Today Suzuki will be interviewing his students to ensure they are progressing in their training.
        /// He decided to schedule the interviews based on the length of the students name in descending order. 
        /// The students will line up and wait for their turn.
        /// You will be given a string of student names. Sort them and return a list of names in descending order.
        /// Here is an example input:
        /// string = 'Tadashi Takahiro Takao Takashi Takayuki Takehiko Takeo Takeshi Takeshi'
        /// Here is an example return from your function:
        /// lst = ['Takehiko',
        /// 'Takayuki',
        /// 'Takahiro',
        /// 'Takeshi',
        /// 'Takeshi',
        /// 'Takashi',
        /// 'Tadashi',
        /// 'Takeo',
        /// 'Takao']
        /// Names of equal length will be returned in reverse alphabetical order (Z->A) such that:
        /// string = "xxa xxb xxc xxd xa xb xc xd"
        /// Returns
        /// ['xxd', 'xxc', 'xxb', 'xxa', 'xd', 'xc', 'xb', 'xa']
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static String[] LineupStudents(String a)
        {
            // Create an array from string
            string[] arr = a.Split();
            // Order list by string length
            arr = arr.OrderBy(aux => aux.Length).ToArray();
            // Divide all list to part by length and make order for each list
            List<string> preResultList = new List<string>();
            List<string> tempList = new List<string>();
            for (int i = 1; i < arr.Length; i++)
            {
                tempList.Add(arr[i - 1]);

                if (arr[i-1].Length != arr[i].Length)
                {
                    tempList = tempList.OrderBy(c => c).ToList();
                    preResultList.AddRange(tempList);
                    tempList.Clear();
                }

                if (arr.Length - 1 == i)
                {
                    tempList.Add(arr[i]);
                    tempList = tempList.OrderBy(c => c).ToList();
                    preResultList.AddRange(tempList);
                }
            }
            // Reverse list
            preResultList.Reverse();
            string[] resultArr = preResultList.ToArray();
            return resultArr;
        }

        public static String[] LineupStudents2(String a)
        {
            return a.Split(' ').OrderByDescending(person => person.Length).ThenByDescending(person => person).ToArray();
        }

        public static String[] LineupStudents3(String a)
        {
            return a.Split(' ').OrderByDescending(s => s).OrderByDescending(s => s.Length).ToArray();
        }
    }
}
