using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class Memory
    {
        private List<int> Me; //paměť
        private List<Pointer> Pointers; //indexy ukazatelů


        public Memory(List<int> me, List<Pointer> pointers)
        {
            Me = me;
            Pointers = pointers;
        }

        public int GetFirstPointerValue()
        {
            return Me[Pointers[0].Position];
        }

        public int GetValueAtPosition(int index)
        {
            return Me[index];
        }

        public void MovePointers(int index)
        {
            //Pointers.ForEach(Console.Write);
            for (int i=Pointers.Count-1; i>0; i--)
            {
                Console.WriteLine("moving");
                Pointers[i].Position = Pointers[i - 1].Position;
                
            }
            Pointers[0].Position = index;
            //Pointers.ForEach(Console.Write);
        }

        public void Add()
        {
            int sum = 0;
            foreach (Pointer element in Pointers)
            {
                sum = sum + GetValueAtPosition(element.Position);
            }
            Me[GetFirstPointerValue()] = sum;
        }

        public void PrintForDebuging()
        {
            Console.Write("Memory: ");
            Me.ForEach(Console.Write);
            Console.WriteLine();
            Console.Write("Pointers: ");
            foreach (Pointer pointer in Pointers)
            {
                Console.Write(pointer.Position);
            }
            Console.WriteLine();
        }
    }
}
