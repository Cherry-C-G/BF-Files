// C# program for reversing the linked list
using System;

class Program
{

	// Driver Code
	static void Main(string[] args)
	{
		LinkedList list = new LinkedList();
		list.AddNode(new LinkedList.Node(89));
		list.AddNode(new LinkedList.Node(90));
		list.AddNode(new LinkedList.Node(7));
		list.AddNode(new LinkedList.Node(22));

		// List before reversal
		Console.WriteLine("Given linked list ");
		list.PrintList();

		// Reverse the list
		list.ReverseList();

		// List after reversal
		Console.WriteLine("Reversed linked list ");
		list.PrintList();
	}
}

class LinkedList
{
	Node head;

	public class Node
	{
		public int data;
		public Node next;

		public Node(int d)
		{
			data = d;
			next = null;
		}
	}

	// function to add a new node at
	// the end of the list
	public void AddNode(Node node)
	{
		if (head == null)
			head = node;
		else
		{
			Node temp = head;
			while (temp.next != null)
			{
				temp = temp.next;
			}
			temp.next = node;
		}
	}

	// function to reverse the list
	public void ReverseList()
	{
		Node prev = null, current = head, next = null;
		while (current != null)
		{
			next = current.next;
			current.next = prev;
			prev = current;
			current = next;
		}
		head = prev;
	}

	// function to print the list data
	public void PrintList()
	{
		Node current = head;
		while (current != null)
		{
			Console.Write(current.data + " ");
			current = current.next;
		}
		Console.WriteLine();
	}
}

// This code is contributed by Mayank Sharma
