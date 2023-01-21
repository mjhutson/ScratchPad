using System;
using System.IO;

namespace ScratchPad
{
    class Program
    {
        static void Main()
        {
            var c4 = new ConnectFour();
            Console.WriteLine(c4.play());
        }

        static void setup(){
            var input = getInput();
            int g = Convert.ToInt32(input[0]);

            for (int gItr = 1; gItr < g; gItr++) {
                string[] nms = input[gItr].Split(' ');
                int numberOfNodes = Convert.ToInt32(nms[0]);
                int numberOfEdges = Convert.ToInt32(nms[1]);
                int minimunSpanningTree = Convert.ToInt32(nms[2]);

                var result = minimumWeight(numberOfNodes, numberOfEdges, minimunSpanningTree);
                Console.WriteLine($"{result}");
            }
        }

        static string[] getInput(){
            string[] lines = File.ReadAllLines("/Users/matthutson/Documents/Programming/ScratchPad/ScratchPad/input.txt");
            return lines;
        }
    
        static int minimumWeight(int numberOfNodes, int numberOfEdges, int minimunSpanningTree) {
            try{
                if (numberOfEdges <= (numberOfNodes - 1)*(numberOfNodes - 2)/2 + 1) {
                    return numberOfEdges + minimunSpanningTree - numberOfNodes + 1;
                }
            int core = (numberOfNodes - 1)*(numberOfNodes - 2)/2;
            int unbalanced = core + (minimunSpanningTree - numberOfNodes + 2)*(numberOfEdges - core);

            int temp = minimunSpanningTree/(numberOfNodes - 1);
            int larger = minimunSpanningTree - temp*(numberOfNodes - 1);
            int smaller = numberOfNodes - 1 - larger;
            int midbalanced = temp*core + (temp + larger)*(numberOfEdges - core);

            int balanced;
            if (larger > 0) {
                core = smaller*(smaller + 1)/2;
                balanced = temp*core + (temp + 1)*(numberOfEdges - core);
            } else {
                balanced = temp*numberOfEdges;
            }

            return Min(Min(unbalanced, balanced), midbalanced);
            } catch (Exception e){
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    
        static int Min(int x, int y){
            if(x > y){
                return y;
            }
            else{
                return x;
            }
        }
    }
}
