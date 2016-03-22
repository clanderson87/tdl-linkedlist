using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedListNode FirstLocation { get; set; }

        public SinglyLinkedList()
        {
            
        }

        public override string ToString()
        {
            string toString = "{ ";
            SinglyLinkedListNode newNode = FirstLocation;
            
            if (newNode == null)
            {
                return "{ }";
            }

            while (newNode != null)
            {
                toString += "\"" + newNode.Value + "\""; 
                newNode = newNode.Next;
                if(newNode != null)
                {
                    toString += ", ";
                }
            }
            toString += " }";
            return toString;
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            //for (int i = 0; i < values.Length; i++)
            //{
            //    this.AddLast(values[i] as String);
            //}
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return this[i]; }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode willBeFirst = new SinglyLinkedListNode(value);
            willBeFirst.Next = FirstLocation;
            FirstLocation = willBeFirst;
        }

        public void AddLast(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);

            if (this.First() == null)
            {
                FirstLocation = newNode;   
            }
            else
            {
                SinglyLinkedListNode latestNode = FirstLocation;
                while(!(latestNode.IsLast()))
                {
                    latestNode = latestNode.Next;
                }
                latestNode.Next = newNode;
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            int count = 0;
            
            if(FirstLocation != null)
            {
                SinglyLinkedListNode incrementer = FirstLocation;
                while (incrementer != null)
                {
                    incrementer = incrementer.Next;
                    count++;
                }
                return count;
            }
            else { return 0; }
            
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode incrementer = FirstLocation;

            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for(int i = 0; i < index; i++)
                {
                    incrementer = incrementer.Next;
                }
                return incrementer.Value.ToString();
            }
        }

        public string First()
        {
            return FirstLocation?.ToString();
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            SinglyLinkedListNode LastNode = FirstLocation;

            if (LastNode == null)
            {
                return null;
            }
            else
            {
                while (LastNode.Next != null)
                {
                    LastNode = LastNode.Next;
                }
                return LastNode.Value.ToString();
            }
            
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        } 

        public string[] ToArray()
        {
            int count = this.Count();
            SinglyLinkedListNode newNode = FirstLocation;
            string[] toArray = new string[count];
            

            int i = 0;
            while (newNode != null)
            {
                toArray[i] = newNode.Value;
                i++;
                newNode = newNode.Next;
            }
            //toArray[count - 1] = this.Last();
            return toArray;
            
            /*for (int i = 0; i < count; i++)
            {
                toArray[i] = newNode.Value;
                newNode = newNode.Next;
            }
            return toArray;*/
        }
    }
}
