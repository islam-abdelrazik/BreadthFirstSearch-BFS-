using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class Node
    {
        public int No;
        public List<Node> Adjacents;
        public Node(int no)
        {
            this.No = no;
            this.Adjacents = new List<Node>();
        }
        public void AddAjacent(Node adj)
        {
            this.Adjacents.Add(adj);
        }
    }

    public class Graph
    {
        private List<Node> visited;
        private Node _start;
        private Node _destination;
        public Graph(Node start, Node destination)
        {
            this._start = start;
            this._destination = destination;
            visited = new List<Node>();
        }
        public void BFS()
        {
            Node current = _start;
            Queue<Node> remainingNodes = new Queue<Node>();
            remainingNodes.Enqueue(current);
            while (remainingNodes.Any())
            {
                current = remainingNodes.Dequeue();

                if (current == _destination)
                {
                    Console.Write(_destination.No);
                    return;
                }
                else
                {
                    if (!visited.Any(d => d == current))
                    {
                        visited.Add(current);
                        Console.Write(current.No + " ");
                        foreach (var adj in current.Adjacents)
                        {
                            remainingNodes.Enqueue(adj);
                        }
                    }
                }


            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Node n0 = new Node(0);
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            n0.AddAjacent(n1);
            n0.AddAjacent(n2);
            n1.AddAjacent(n2);
            n2.AddAjacent(n0);
            n2.AddAjacent(n3);
            n3.AddAjacent(n3);

            Graph graph = new Graph(n2, n1);
            graph.BFS();
            Console.ReadLine();


        }
    }
}
