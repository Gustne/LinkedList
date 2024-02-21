//Author: Per Larsen

using System;



LinkedList linkedlist = new LinkedList();
linkedlist.Add(3);
linkedlist.Add(7);
linkedlist.Add(5);
linkedlist.Add(6);
Console.WriteLine(linkedlist.InsertAfter(2, 125));
linkedlist.PrintAll();
Console.WriteLine(linkedlist.deleteElement(3));
linkedlist.PrintAll();
linkedlist.PrintUneven();
Console.WriteLine(linkedlist.CalculateSum());



class LinkedList
{
    private Node chain;

    public LinkedList()
    {
        chain = null;
    }

    public void Add(int value)
    {
        Node node = new Node(value, chain);
        node.data = value;
        node.next = chain;
        chain = node;
    }

    public void PrintAll()
    {
        Node temp = chain;
        while (temp != null)
        {
            Console.WriteLine("tmp.data =" + temp.data);
            temp = temp.next;
        }
    }

    public void PrintUneven()
    {
        Node temp = chain;
        while(temp != null)
        {
            if (temp.data%2 != 0)
            {
                Console.WriteLine(temp.data);
            }

            temp = temp.next;
        }
    }

    public int CalculateSum()
    {
        int sum = 0;
        Node temp = chain;
        while(temp != null)
        {
            sum += temp.data;
            temp = temp.next;
        }

        return sum;
    }

    public bool InsertAfter(int position, int value)
    {
        Node temp = chain;
        int count = 1;

        while(count <= position && temp != null)
        {
            if (count == position)
            {

                temp.next = new Node(value, temp.next);

                return true;
            }

            temp = temp.next;
            count++;
        }

        return false;


    }

    public bool deleteElement(int position)
    {
        Node temp = chain;
        int count = 1;

        if (position == 1)
        {
            this.chain = chain.next;
            return true;
        }

        while (count < position && temp != null)
        {
            if (count == position - 1)
            {

                temp.next = temp.next.next;
                return true;
            }

            temp = temp.next;
            count++;
        }

        return false;
    }
}

public class Node
{
    public Node()
    {
        this.data = 0;
        this.next = null;
    }
    public Node(int data, Node next)
    {
        this.data = data;
        this.next = next;
    }

    public int data { get; set; }
    public Node next { get; set; }

}