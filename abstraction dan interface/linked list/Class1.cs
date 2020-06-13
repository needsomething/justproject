using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list
{
    class Node
    {
        public Node(int new_data)
        {
            data = new_data;
        }
        public int data;
        public Node next;
    }

    interface IQueue
    {
        Node Add_empty(Node Root, int new_data);
        Node Add_begin(Node Root, int new_data);
        Node Add_end(Node Root, int new_data);
        Node Add_after(Node Root,int after, int new_data);
        Node Pop(Node Root);
        void Print_list(Node Root);
    }

    class Queue_list : IQueue
    {
        public Node Add_empty(Node Root, int new_data)
        {
            Node new_node = new Node(new_data);

            Root = new_node;
            new_node.next = Root;
            return Root;
        }

        public Node Add_begin(Node Root, int new_data)
        {
            if(Root == null)
            {
                Root = Add_empty(Root, new_data);
                return Root;
            }
            Node new_node = new Node(new_data);

            new_node.next = Root.next;
            Root.next = new_node;
            return Root;
        }

        public Node Add_end(Node Root, int new_data)
        {
            if(Root == null)
            {
                Root = Add_empty(Root, new_data);
                return Root;
            }
            Node new_node = new Node(new_data);
            new_node.next = Root.next;
            Root.next = new_node;
            Root = new_node;
            return Root;
        }

        public Node Add_after(Node Root, int after, int new_data)
        {
            if(Root == null)
            {
                return Root;
            }
            Node new_node, p;
            p = Root.next;
            do
            {
                if(p.data == after)
                {
                    new_node = new Node(new_data);
                    new_node.next = p.next;
                    p.next = new_node;
                    if(p == Root)
                    {
                        Root = new_node;
                        return Root;
                    }
                    return Root;
                }
                p = p.next;
            } while (p != Root.next);
            return Root;
        }

        public Node Pop(Node Root)
        {
            if(Root == null)
            {
                return Root;
            }
            if (Root.next == Root) 
            {
                Root = null;
                return Root;
            }
            Node p = Root.next;
            Root.next = p.next;
            return Root;
        }

        public void Print_list(Node Root)
        {
            if(Root == null)
            {
                return;
            }
            Node p;
            p = Root.next;
            do
            {
                Console.Write("{0} ", Convert.ToString(p.data));
                p = p.next;
            } while (p != Root.next);
        }
    }
}
