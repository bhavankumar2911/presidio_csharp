using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeProblemsApp
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    internal class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            HashSet<ListNode> nodes = new HashSet<ListNode>();

            while (head != null)
            {
                if (nodes.Contains(head))
                {
                    return true;
                }

                nodes.Add(head);
                head = head.next;
            }

            return false;
        }
    }
}
