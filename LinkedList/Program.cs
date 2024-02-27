//Author: Per Larsen

using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;

LinkedList linkedlist = new LinkedList();
linkedlist.Add(3);
linkedlist.Add(7);
linkedlist.Add(5);
linkedlist.Add(6);
linkedlist.Add(43);
linkedlist.Add(21);
linkedlist.Add(223);
linkedlist.Add(3);
linkedlist.Add(5);
linkedlist.Add(62);
linkedlist.Add(16);
linkedlist.Add(23);
linkedlist.Add(75);
linkedlist.Add(12);
Console.WriteLine(linkedlist.InsertAfter(2, 125));
linkedlist.PrintAll();
Console.WriteLine(linkedlist.DeleteElement(3));
linkedlist.PrintAll();
linkedlist.PrintUneven();
Console.WriteLine($"Summen er :{linkedlist.CalculateSumAndAverage(out double average)}");
Console.WriteLine($"gennemsnittet er {average}");

linkedlist.AddUnderTop(1);
Console.WriteLine($"her er første værdi {linkedlist.LoadFirst()}");
Console.WriteLine($"slet første status {linkedlist.DeleteFirst()}");
Console.WriteLine($"nu er første værdi: {linkedlist.LoadAndDeleteFirst()} og den er slettet");



LinkedList newList = linkedlist.GetInterval(4, 9);
Console.WriteLine("printer nu fra den nye liste med intervallet af den gamle");
newList.PrintAll();

Console.WriteLine("her samler vi de 2 lister og printer de samlede ud");
LinkedList conCatlist = LinkedList.Concat(linkedlist, newList);

conCatlist.PrintAll();
Console.WriteLine("her printer vi den i omvendt rækkefølge");
conCatlist.PrintReverse();

class LinkedList
{
    private Node chain;

    public LinkedList()
    {
        chain = null;
    }

    public LinkedList(Node chain)
    {
        this.chain = chain;
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

    public int CalculateSumAndAverage(out double average)
    {
        int sum = 0;
        int count = 0;
        Node temp = chain;
        while(temp != null)
        {
            sum += temp.data;
            temp = temp.next;
            count++;
        }

        average = (double) sum/count;
        return sum;
    }

    public bool InsertAfter(int position, int value)
    {
        Node temp = chain;
        int count = 1;

        while(temp != null)
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

    public bool DeleteElement(int position)
    {
        Node temp = chain;
        int count = 1;

        if (position == 1)
        {
            this.chain = chain.next;
            return true;
        }

        while (temp != null)
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


    // AddUnderTop(int tal) der kan indsætte elementer efter det første element
    public bool AddUnderTop(int value)
    {
        return InsertAfter(1, value);
    }
    //Int HentFørste()
    public int? LoadFirst()
    {
        if (chain != null)
        {
            return chain.data;
        }
        else
        {
            return null;
        }
    }
    //slet første
    public bool DeleteFirst()
    {
        return DeleteElement(1);
    }

    // load and delete first
    public int? LoadAndDeleteFirst()
    {
        if(chain != null)
        {
            int? value = LoadFirst();
            DeleteFirst();
            return value;
        }
        else
        {
            return null;
        }
    }

    //beregn snit ** er bygget ind i sum funktionen

    //  Konstruer en ekstra metode til vores LL-linkedList programeksempel
    //  der kan returnere en NY liste med de værdier der ligger i et bestemt
    //  interval
    public LinkedList GetInterval(int start, int end)
    {
        Node temp = chain;
        int count = 1;
        Node newChain = null;

        while (temp != null)
        {
            if (count == start)
            {
                newChain = temp;
            }

            if (count == end)
            {
                temp.next = null;
                return new LinkedList(newChain);
            }

            temp = temp.next;
            count++;
        }

        return new LinkedList();
    }


    // sæt 2 lister sammen
    // Man kan ikke bare sætte dem samme fordi det kan lave loops hvis du bruger en interval af en anden liste og sætter sammen
    public static LinkedList Concat(LinkedList list1, LinkedList list2)
    {

        LinkedList reverseList = new LinkedList();

        Node temp = list1.chain;

        while (temp != null)
        {
            reverseList.Add(temp.data);
            temp = temp.next;
        }

        temp = reverseList.chain;

        while(temp != null)
        {
            list2.Add(temp.data);
            temp = temp.next;
        }
        
        return list2;
    }


    // Lav en funktion der printer listen ud i omvendt rækkefølge
    public void PrintReverse()
    {
        LinkedList reverseList = new LinkedList();

        Node temp = chain;

        while (temp!= null)
        {
            reverseList.Add(temp.data);
            temp = temp.next;
        }

        reverseList.PrintAll();
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

