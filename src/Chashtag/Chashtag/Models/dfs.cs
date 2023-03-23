using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using stima2;

namespace Stima2
{
    public class DFS
    {   
        // attribute
        public Stack<GraphNode> check;
        public List<GraphNode> exploredNode;
        public List<char> move;
        public Graph theGraph;
        public List<Tuple<int, int, string>> DFSPath;
        public List<GraphNode> pileOfTreasure;
        public int countSteps;

        // ctor
        public DFS()
        {
            this.check = new Stack<GraphNode>();
            this.move = new List<char>();
            this.theGraph = new Graph();
            this.exploredNode = new List<GraphNode>();
            this.DFSPath = new List<Tuple<int, int, string>>();
            this.pileOfTreasure= new List<GraphNode>();
            this.countSteps = 0;
         }

        // user - defined ctor
        public DFS(Graph theGraph)
        {
            this.theGraph = theGraph;
            this.check = new Stack<GraphNode>();
            this.move = new List<char>();
            this.exploredNode= new List<GraphNode>();
            this.pileOfTreasure= new List<GraphNode>();
            this.DFSPath = new List<Tuple<int, int, string>>();
            this.countSteps = 0;
        }

        // getter
        public List<char> getMove()
        {
            return this.move;
        }

        // cek sebuah node ada di list atau tidak
        public bool isNodeInList(GraphNode x)
        {
            foreach(GraphNode node in this.exploredNode) 
            {
                if(x.getX() == node.getX() && x.getY() == node.getY())
                {
                    return true;
                }
            }
            return false;
        }

        // cari titik start untuk di Push ke stack dan ditambah ke explored node
        public void findStart()
        {
            foreach(KeyValuePair<int, GraphNode> node in this.theGraph.nodes)
            {
                if(node.Value.isStart())
                {
                    this.check.Push(node.Value);
                    this.exploredNode.Add(node.Value);
                    break;

                }
            }
        }

        public void printDFSPath()
        {
            foreach(Tuple<int, int, string> path in this.DFSPath) 
            {
                Console.WriteLine("{0}", path.Item3);
            }
        }

        public bool isPathInDFSPath(Tuple<int, int, string> x)
        {

            foreach (Tuple<int, int, string> paths in this.DFSPath)
            {
                if (x.Item1 == paths.Item1 && x.Item2 == paths.Item2)
                {
                    return true;
                }
            }
            return false;
        }

        public bool NodeInTRS(GraphNode n)
        {
            foreach(GraphNode x in this.pileOfTreasure)
            {
                if(x.getY() == n.getY() && x.getX() == n.getX())
                {
                    return true;
                }
           
            }
            return false;
        }

        public void printStack()
        {
            foreach(GraphNode n in this.check)
            {
                Console.Write(n.getName() + " ");
            }
            Console.WriteLine();
        }

        public void printExplored()
        {
            foreach(GraphNode n in this.exploredNode)
            {
                Console.Write(n.getName() + " ");
            }
            Console.WriteLine();
        }

        public void printMove()
        {
            foreach(char m in this.getMove())
            {
                Console.Write(m + " ");
            }
            Console.WriteLine();
        }

        public int getCountSteps()
        {
            return this.countSteps;
        }

        // algoritma DFS utama 
        public void runDFS()
        {
            // prioritas gerakan : RIGHT UP DOWN LEFT 

            // cari starting point
            this.findStart();
            int trs = this.theGraph.getNumOfTreasure();
            string dir = "LDUR";
            
            while (this.theGraph.getNumOfTreasure() > 0) // selama treasure belum habis di map
            {

                // curr adalah GraphNode yang sedang diperiksa
                GraphNode curr = check.Pop();

                if(curr.isTreasure()) // menemukan treasure
                {   
                    this.theGraph.setNumOfTreasures(this.theGraph.getNumOfTreasure()-1); // kurangi jumlah treasure di map
                    this.pileOfTreasure.Add(curr); // simpan treasure dalam tumpukan treasure
                    curr.setTreasure(false); // tandai bahwa treasure telah diambil

                    List<Tuple<int, int, string>> g = curr.getPath();
                    g.Reverse();
                    foreach(Tuple<int, int, string> t in g)
                    {
                        this.DFSPath.Add(t);
                    }

                    // hapus path dari seluruh node 
                    foreach(KeyValuePair<int, GraphNode> kvp in this.theGraph.nodes)
                    {
                        kvp.Value.clearPath();
                    }

                    // kosongkan stack dan node yang telah di explore
                    this.check.Clear();
                    this.exploredNode.Clear();

                }
               

                // inisiasi sementara agar tidak null
                GraphNode next = curr;

                // menambahkan jalur baru yang bisa di check
                foreach(char c in dir)
                {   
                    if(curr.hasNeighbor())
                    {
                        if (c == 'L' && curr.getLeft() != null)
                        {
                            next = curr.getLeft();
                            next.connectPath(curr);
                        }
                        else if (c == 'D' && curr.getDown() != null)
                        {
                            next = curr.getDown();
                            next.connectPath(curr);
                        }
                        else if (c == 'U' && curr.getUp() != null)
                        {
                            next = curr.getUp();
                            next.connectPath(curr);
                        }
                        else if (c == 'R' && curr.getRight() != null)
                        {
                            next = curr.getRight();
                            next.connectPath(curr);
                        }
                        
                        if(this.isNodeInList(next))
                        {
                            continue;
                        }
                        this.exploredNode.Add(next);
                        this.check.Push(next);
                    }

                }
            }


            // buat jalur treasure 

            //List<Tuple<int, int, string>> sementara = this.pileOfTreasure[trs - 1].getPath();
            //sementara.Reverse();
            //foreach (Tuple<int, int, string> p in sementara)
            //{
            //    this.DFSPath.Add(p);
            //}

            for(int i = 0; i < this.DFSPath.Count-1; i++)
            {
                Tuple<int, int, string> p1 = this.DFSPath[i];
                Tuple<int, int, string> p2 = this.DFSPath[i + 1];

                char m = 'X';
                if(p2.Item1 == p1.Item1 + 1 && p2.Item2 == p1.Item2)
                {
                    m = 'D';
                }
                else if(p2.Item1 == p1.Item1-1 && p2.Item2 == p1.Item2)
                {
                    m = 'U';
                }
                else if(p2.Item1 == p1.Item1 && p2.Item2 == p1.Item2+1)
                {
                    m = 'R';
                }
                else if(p2.Item1 == p1.Item1 && p2.Item2 == p1.Item2-1)
                {
                    m = 'L';
                }
                else if(p2.Item1 == p1.Item1 && p2.Item2 == p1.Item2)
                {
                    m = 'T';
                }

                this.move.Add(m);
            }
            this.move.Add('T');

            foreach(char c in this.move)
            {
                if(c != 'T'){
                    this.countSteps++;
                }
            }
        }

        public static void Main(string[] args)
        {
            Graph m1 = new Graph("test.txt");
            m1.setUpGraph();
            DFS test = new DFS(m1);
            test.runDFS();
            test.printDFSPath();
            test.printMove();
        }
    }
}
