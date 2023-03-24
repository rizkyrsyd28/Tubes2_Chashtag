using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace stima2
{
    public class GraphNode
    {
        // attribute
        private bool visited;
        private bool treasure;
        private bool start;
        private int x_kor;
        private int y_kor;
        private string name;
        private GraphNode? up;
        private GraphNode? down;
        private GraphNode? left;
        private GraphNode? right;
        private List<Tuple<int, int, string>> path;

        public GraphNode()
        {
            this.visited = false;
            this.treasure = false;
            this.start = false;
            this.up = null;
            this.down = null;
            this.left = null;
            this.right = null;
            this.x_kor = 0;
            this.y_kor = 0;
            this.name = "";
            this.path = new List<Tuple<int, int, string>>();
            this.path.Add(new Tuple<int, int, string>(0, 0, this.name));
        }

        public GraphNode(bool v, bool t, bool s, GraphNode? u, GraphNode? d, GraphNode? l, GraphNode? r, int x, int y, string name, List<Tuple<int, int, string>> path)
        {
            this.visited = v;
            this.treasure = t;
            this.start = s;
            this.up = u;
            this.down = d;
            this.left = l;
            this.right = r;
            this.x_kor = x;
            this.y_kor = y;
            this.name = name;
            this.path = path;
        }

        // getter 
        public bool getVisited()
        {
            return this.visited;
        }

        public bool isTreasure()
        {
            return this.treasure;
        }

        public bool isStart()
        {
            return this.start;
        }

        public GraphNode getUp()
        {
            return this.up;
        }

        public GraphNode getDown()
        {
            return this.down;
        }

        public GraphNode getLeft()
        {
            return this.left;
        }

        public GraphNode getRight()
        {
            return this.right;
        }

        public int getX()
        {
            return this.x_kor;
        }

        public int getY()
        {
            return this.y_kor;
        }

        public bool hasNeighbor()
        {
            return (this.left != null || this.right != null || this.up != null || this.down != null);
            
        }

        public string getName()
        {
            return this.name;
        }

        public List<Tuple<int, int, string>> getPath()
        {
            return this.path;
        }

        public Tuple<int, int, string> getInfo()
        {
            return new Tuple<int, int, string>(this.x_kor, this.y_kor, this.name);
        }

        // setter 
        public void setVisited(bool v)
        {
            this.visited = v;
        }

        public void setTreasure(bool t)
        {
            this.treasure = t;
        }

        public void setStart(bool s)
        {
            this.start = s;
        }

        public void setUp(GraphNode u)
        {
            this.up = u;
        }

        public void setDown(GraphNode d)
        {
            this.down = d;
        }

        public void setLeft(GraphNode l)
        {
            this.left = l;
        }

        public void setRight(GraphNode r)
        {
            this.right = r;
        }

        public void setX(int x)
        {
            this.x_kor = x;
        }

        public void setY(int y)
        {
            this.y_kor = y;
        }
        
        public void setName(string name)
        {
            this.name = name;
        }

        public void connectPath(GraphNode l)
        {
            foreach(Tuple<int, int, string> node in l.getPath())
            {
                //if(!this.pathIn(node))
                //{
                //    this.path.Add(node);
                //}
                this.path.Add(node);
            }
        }

        public void clearPath()
        {
            this.path.Clear();
            this.path.Add(new Tuple<int, int, string>(this.x_kor, this.y_kor, this.name));
        }

        public void printPath()
        {
            foreach(Tuple<int, int, string> p in this.path)
            {
                Console.Write(p.Item3 + " ");
            }
            Console.WriteLine();
        }

        public bool pathIn(Tuple<int,int, string> p)
        {
            foreach(Tuple<int,int,string> x in this.path)
            {
                if (p.Item1 == x.Item1 && p.Item2 == x.Item2)
                {
                    return true;
                }
            }
            return false;
        }

        //public int countNeighbor()
        //{
        //    int count = 0;
        //    if(this.getLeft() != null)
        //    {
        //        count++;
        //    }

        //    if(this.getRight() != null)
        //    {
        //        count++;
        //    }

        //    if(this.getDown() != null)
        //    {
        //        count++;
        //    }

        //    if(this.getUp() != null)
        //    {
        //        count++;
        //    }
        //    return count;
        //}
    }

    public class Graph
    {
        private int sizeX;
        private int sizeY;
        private char[,] map;
        public Dictionary<int, GraphNode> nodes;
        public int numOfNodes;
        public int numOfTreasure;
        public Graph()
        {
            sizeX = 0; sizeY = 0;
            nodes = new Dictionary<int, GraphNode>();
            numOfNodes = 0;
            numOfTreasure = 0;
        }

        public Graph(string path) // membentuk graph dari file txt 
        {
            int K_count = 0;
            int T_count = 0;
            int R_count = 0;

            nodes = new Dictionary<int, GraphNode>();
            numOfNodes = 0;
            numOfTreasure = 0;
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            string line = lines[0];
            this.sizeX = line.Length;
            this.sizeY = lines.Count;
            this.map = new char[sizeY, sizeX];

            for(int row = 0; row < lines.Count; row++)
            {
                for(int col = 0; col < line.Length; col++)
                {
                    map[row,col] = lines[row][col];
                    if (lines[row][col] == 'K')
                    {   
                        numOfNodes++;
                        string nama = "N" + col.ToString() + row.ToString();
                        List<Tuple<int, int, string>> paths = new List<Tuple<int, int, string>>();
                        paths.Add(new Tuple<int, int, string>(row, col, nama));
                        GraphNode n = new GraphNode(false, false, true, null, null, null, null, row, col,nama, paths);
                        K_count++;
                        nodes.Add(numOfNodes, n);
                    }
                    else if (lines[row][col] == 'T')
                    {   
                        numOfNodes++;
                        numOfTreasure++;
                        string nama = "N" + col.ToString() + row.ToString();
                        List<Tuple<int, int, string>> paths = new List<Tuple<int, int, string>>();
                        paths.Add(new Tuple<int, int, string>(row, col, nama));
                        GraphNode n = new GraphNode(false, true, false, null, null, null, null, row, col, nama, paths);
                        T_count++;
                        nodes.Add(numOfNodes, n);   
                    }
                    else if (lines[row][col] == 'R')
                    {   
                        numOfNodes++;
                        string nama = "N" + col.ToString() + row.ToString();
                        List<Tuple<int, int, string>> paths = new List<Tuple<int, int, string>>();
                        paths.Add(new Tuple<int, int, string>(row, col, nama));
                        GraphNode n = new GraphNode(false, false, false, null, null, null, null, row, col, nama, paths);
                        R_count++;
                        nodes.Add(numOfNodes, n); 
                    }
                    else if (lines[row][col] == 'X')
                    {
                        continue;
                    }
                    else
                    {
                        throw new Exception("Isi file salah, terdapat karakter selain 'K', 'R', 'X', atau 'T'");
                    }
                    
                }
            }

            if(!(K_count == 1 && T_count > 0 && R_count > 0))
            {
                Console.WriteLine(K_count);
                Console.WriteLine(T_count);
                Console.WriteLine(R_count);
                throw new Exception();
            }
            
        }

        public void setUpGraph()
        {
            foreach (KeyValuePair<int, GraphNode> node1 in nodes)
            {
                GraphNode? up = null;
                GraphNode? down = null;
                GraphNode? left = null;
                GraphNode? right = null;

                foreach (KeyValuePair<int, GraphNode> node2 in nodes)
                {
                    if (node2.Value.getX() == node1.Value.getX() && node2.Value.getY() == node1.Value.getY() - 1)
                    {
                        left = node2.Value;
                    }
                    else if (node2.Value.getX() == node1.Value.getX() && node2.Value.getY() == node1.Value.getY() + 1)
                    {
                        right = node2.Value;
                    }
                    else if (node2.Value.getX() == node1.Value.getX() - 1 && node2.Value.getY() == node1.Value.getY())
                    {
                        up = node2.Value;
                    }
                    else if (node2.Value.getX() == node1.Value.getX() + 1 && node2.Value.getY() == node1.Value.getY())
                    {
                        down = node2.Value;
                    }
                }

                node1.Value.setUp(up);
                node1.Value.setDown(down);
                node1.Value.setLeft(left);
                node1.Value.setRight(right);
            }
        }

        public int getNumOfNodes()
        {
            return this.numOfNodes;
        }

        public int getNumOfTreasure()
        {
            return this.numOfTreasure;
        }

        public int getSizeGrafX(){
            return this.sizeX;
        }

        public int getSizeGrafY(){
            return this.sizeY;
        }

        public char[,] getMap(){
            return this.map;
        }

        public void setNumOfNodes(int numOfNodes) 
        {
            this.numOfNodes = numOfNodes;
        }

        public void setNumOfTreasures(int numOfTreasures)
        {
            this.numOfTreasure = numOfTreasures;
        }

    }
}