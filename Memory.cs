using System;
using System.Collections.Generic;
using System.Text;

namespace Turing
{
    class Memory
    {
        private List<int> Content; //paměť
        private List<Pointer> Pointers; //indexy ukazatelů


        public Memory(List<int> content, List<Pointer> pointers)
        {
            Content = content;
            Pointers = pointers;
        }

        public int GetValueUnderPointer(Pointer pointer)
        {
            return Content[pointer.Position];
        }

        public Pointer GetFirstPointer()
        {
            return Pointers[0];
        }

        private int GetValueAtPosition(int index)
        {
            return Content[index];
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
            Content[GetFirstPointer().Position] = sum;
        }

        public void Subtract()
        {
            int sum = this.GetValueUnderPointer(this.GetFirstPointer());
            for (int i=1;i<Pointers.Count;i++)
            {
                sum = sum - GetValueUnderPointer(Pointers[i]);
            }
            Content[GetFirstPointer().Position] = sum;
        }

        public void PrintForDebuging()
        {
            Console.Write("Memory: ");
            Content.ForEach(Console.Write);
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
