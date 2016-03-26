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
                if (newNode != null)
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
            for (int i = 0; i < values.Length; i++)
            {
                this.AddLast(values[i] as String);
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return this.ElementAt(i); }
            set {
                SinglyLinkedListNode FLnode = FirstLocation;
                SinglyLinkedListNode nextNode = new SinglyLinkedListNode(value);

                if (i == 0)
                {
                    var getNext = FLnode.Next;
                    FirstLocation = nextNode;
                    nextNode.Next = getNext;
                    return;
                }
                else
                {
                    SinglyLinkedListNode before = this.NodeAt(i - 1);
                    before.Next = nextNode;
                }
           }//end setter

        }

        public SinglyLinkedListNode NodeAt(int index)
        {
            SinglyLinkedListNode incrementer = FirstLocation;
            string str = this.ElementAt(index);

            for (int i = 0; i <= index; i++)
            {
                if(i == index && incrementer.Value == str)
                {
                    return incrementer;
                }
                incrementer = incrementer.Next;
            }
            throw new ArgumentOutOfRangeException();
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            SinglyLinkedListNode incrementer = FirstLocation;
            int count = this.Count();

            for (int i = 0; i < count; i++)
            {
                if (incrementer.Value == existingValue)
                {
                    SinglyLinkedListNode oldNode = incrementer;
                    newNode.Next = incrementer.Next;
                    oldNode.Next = newNode;
                    break;
                }
                else if (i == (count - 1) && incrementer.Value != existingValue)
                {
                    throw new ArgumentException();
                }
                else
                {
                    incrementer = incrementer.Next;
                }
            } //close forLoop

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
                while (!(latestNode.IsLast()))
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

            if (FirstLocation != null)
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
                for (int i = 0; i < index; i++)
                {
                    if(incrementer.Next == null)
                    {
                        break;//because I don't want to set incrementer to null, throws NullRefExcep
                    }
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
            string[] thisArray = this.ToArray();
            for (int i = 0; i < thisArray.Length; i++)
            {
                if (thisArray[i].ToString() == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool IsSorted()
        {
            string[] sorted = this.ToArray();

            if(sorted.Length <= 1)
            {
                return true; //because empty / 1 item lists are inherently sorted;
            }
            else
            {
                for (int i = 0; i < sorted.Length; i++)
                //for each item in this list.ToArray();
                {
                    if (this[i].CompareTo(this[i+1]) > 0)
                    //if node compared to the nextNode is greater than 0, than list.IsSorted() == false.
                    {
                        return false;
                    }
                }
                return true;
            }   //insertion sort - assume this
                //merge sort - secondary sort
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
            int count = this.Count();
            int i = this.IndexOf(value);

            if(i >= count || i == -1)
            {
                return;
            }

            if (i == 0)
            {
                FirstLocation = FirstLocation.Next;
            }
            else
            {
                SinglyLinkedListNode before = this.NodeAt(i - 1);
                SinglyLinkedListNode toRemove = before.Next;

                before.Next = toRemove.Next;
            }
        }

        public void RemoveIndex(int i)
        {
            this.Remove(this[i]);
        }

        public void Sort()
        {
            int count = this.Count();
            if (count <= 1)
            {
                return;//return inherantly sorted lists.
            }
            else
            {
                int i = 0;
                //as long as the list isn't sorted
                while (!IsSorted())
                {
                    if (i >= count)
                    {
                        i = 0;
                    } //because if i is greater than count when not sorted is true, everything will break.
                    
                    SinglyLinkedListNode node = this.NodeAt(i);
                    SinglyLinkedListNode nextNode = node.Next;
                    int sortThis = this[i].CompareTo(this[i + 1]);//because node.Value.CompareTo(nextNode.Value) throws a NRE.

                    if (sortThis > 0) // if compareTo renders 1+ (which means not sorted)
                    {
                        if (this.IndexOf(nextNode.Value) != i + 1) //if this picks up an index of node.Value BEFORE i (meaning a dupe).
                        {
                            this.AddAfter(nextNode.Value, nextNode.Value); //find the nextnode (which already exists) and add the dupe after.
                            node.Next = nextNode.Next; //then I kill the old, one-too-many dupe. holy fuck it works.
                        }
                        else
                        {
                            this.AddAfter(nextNode.Value, node.Value); //reverse the order of these two nodes by adding node behind nextNode.
                            this.Remove(node.Value);  //removes the first (incorrectly sorted) occurance of node.Value.
                        }
                    }//end if(sortThis > 0).
                    i++;
                }//end while
            }//end else
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
            return toArray;
        }
    }
}
