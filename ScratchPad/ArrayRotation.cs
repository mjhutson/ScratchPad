using System;
using System.Collections.Generic;
using System.Linq;

namespace ScratchPad
{
    public class ArrayRotation
    {
        public List<int> CircularArrayRotation(
            List<int> listToRotate,
            int numberOfRotations,
            List<int> queries){

            var size = listToRotate.Count;

            var tempList = new List<int>();
            tempList.AddRange(listToRotate.GetRange((size-numberOfRotations), numberOfRotations));

            WriteResultList(tempList);

            tempList.AddRange(listToRotate.GetRange(0, size - numberOfRotations));

            WriteResultList(tempList);

            var resultList = new List<int>();

            foreach (var index in queries)
            {
                resultList.Add(tempList.ElementAt(index));
            }

            return resultList;
        }

        public void WriteResultList(List<int> result)
        {
            foreach (var item in result)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine($"----");
        }
    }
}