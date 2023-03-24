using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TreasureHunt{
    public class Node
    {
        private string name;
        private Tuple<int, int> coor;
        private bool visited;
        private List<Tuple<int, int, string>> path;
        private List<string> orient;
        private Tuple<int, int> U;
        private Tuple<int, int> S;
        private Tuple<int, int> T;
        private Tuple<int, int> B;

        public Node(string _name = "")
        {
            this.name = _name;
            this.coor = new Tuple<int, int>(0, 0);
            this.visited = false;
            this.orient = new List<string>();
            this.path = new List<Tuple<int, int, string>>();
            this.path.Add(new Tuple<int, int, string>(0, 0, _name));
            this.U = null;
            this.S = null;
            this.T = null;
            this.B = null;
        }
        public Node(Node n)
        {
            this.name = n.getName();
            this.coor = new Tuple<int, int>(n.getCoor().Item1, n.getCoor().Item2);
            this.visited = false;
            this.orient = n.getOrient();
            this.path = new List<Tuple<int, int, string>>();
            this.U = n.getUtara();
            this.S = n.getSelatan();
            this.T = n.getTimur();
            this.B = n.getBarat();
        }
        // GETTER
        public Tuple<int, int, string> getInfo()
        {
            return new Tuple<int, int, string>(this.coor.Item1, this.coor.Item2, this.name);
        }
        public string getName()
        {
            return this.name;
        }
        public Tuple<int, int> getCoor()
        {
            return this.coor;
        }
        public List<string> getOrient()
        {
            return this.orient;
        }
        public List<Tuple<int, int, string>> getPath()
        {
            return this.path;
        }
        public Tuple<int, int> getUtara()
        {
            return this.U;
        }
        public Tuple<int, int> getSelatan()
        {
            return this.S;
        }
        public Tuple<int, int> getTimur()
        {
            return this.T;
        }
        public Tuple<int, int> getBarat()
        {
            return this.B;
        }
        public bool isVisited()
        {
            return this.visited;
        }
        public List<string> getPathString()
        {
            List<string> returnPath = new List<string>();
            foreach (var node in path)
            {
                returnPath.Add(node.Item3);
            }
            return returnPath;
        }

        // SETTER
        public void setName(string _name)
        {
            this.name = _name;
        }
        public void setCoor(int x, int y)
        {
            this.coor = new Tuple<int, int>(x, y);
            this.path[0] = new Tuple<int, int, string>(x, y, this.name);
        }
        public void setUtara(int x, int y)
        {
            this.U = new Tuple<int, int>(x, y);
        }
        public void setSelatan(int x, int y)
        {
            this.S = new Tuple<int, int>(x, y);
        }
        public void setTimur(int x, int y)
        {
            this.T = new Tuple<int, int>(x, y);
        }
        public void setBarat(int x, int y)
        {
            this.B = new Tuple<int, int>(x, y);
        }
        public void setVisitNode()
        {
            this.visited = true;
        }
        public void setUnvisitNode()
        {
            this.visited = false;
        }
        // OTHER METHOD
        public void addList(Node l)
        {
            this.path.Add(l.getInfo());
            //this.path.Add(new Tuple<int, int, string>(l.getCoor().Item1, l.getCoor().Item2, l.name));
        }
        public void connectPath(Node l, string orient)
        {
            this.orient.Add(orient);
            foreach (Tuple<int, int, string> node in l.getPath())
            {
                this.path.Add(node);
            }
            foreach (string node in l.getOrient())
            {
                this.orient.Add(node);
            }
        }
        public void clearNodePath()
        {
            this.path.Clear();
            this.orient.Clear();
            // this.path = new List<Tuple<int, int, string>>();
            this.path.Add(new Tuple<int, int, string>(coor.Item1, coor.Item2, this.name));
        }

        // PRINT
        public void printPath()
        {
            Console.Write("[");
            foreach (Tuple<int, int, string> node in this.path)
            {
                Console.Write(node.Item3 + " ");
            }
            Console.WriteLine("]");
        }

        public void printNode()
        {
            Console.WriteLine("{0} - x : {1}, y : {2}", name, coor.Item1, coor.Item2);
            if (this.U != null) Console.WriteLine("\tU - x : {0}, y : {1}", U.Item1, U.Item2);
            else Console.WriteLine("\tU - null");
            if (this.S != null) Console.WriteLine("\tS - x : {0}, y : {1}", S.Item1, S.Item2);
            else Console.WriteLine("\tS - null");
            if (this.T != null) Console.WriteLine("\tT - x : {0}, y : {1}", T.Item1, T.Item2);
            else Console.WriteLine("\tT - null");
            if (this.B != null) Console.WriteLine("\tB - x : {0}, y : {1}", B.Item1, B.Item2);
            else Console.WriteLine("\tB - null");
        }
    }
}