using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Turing
{
    class Memory
    {
        private readonly List<int> Content; //paměť
        private readonly List<Pointer> Pointers; //indexy ukazatelů


        public Memory(List<int> content, List<Pointer> pointers)
        {
            Debug.Assert(pointers.Count > 0, "Memory needs to have at least 1 pointer!");
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
            Debug.Assert(index < Content.Count, "Memory does not have specified index.");
            for (int i=Pointers.Count-1; i>0; i--)
            {
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
                sum += GetValueAtPosition(element.Position);
            }
            Content[GetFirstPointer().Position] = sum;
        }

        public void Subtract()
        {
            int sum = GetValueUnderPointer(GetFirstPointer());
            for (int i=1;i<Pointers.Count;i++)
            {
                sum -= GetValueUnderPointer(Pointers[i]);
            }
            Content[GetFirstPointer().Position] = sum;
        }

        public override string ToString()
        {
            string tbr = "";
            tbr += "Memory: |";
            foreach (int cell in Content)
            {
                tbr += cell;
                tbr += "|";
            }
            tbr += "\nPointers: |";
            foreach (Pointer pointer in Pointers)
            {
                tbr += (pointer.Position);
                tbr += "|";
            }
            tbr += "\n";
            return tbr;
        }
    }
}
