//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace TreasureHunt{
//    public class BFS
//    {
//        private string fileName; 
//        private char[,] map; 
//        private int sizeX;
//        private int sizeY;
//        private Tuple<int,int> start;
//        private Dictionary<Tuple<int,int>, Node> nodes;
//        private Queue<Node> queue; 
//        private int treasure;
//        private int walkable;

//        public BFS(string _file = "") {
//            this.fileName = _file;
//            this.treasure = 0;
//            this.walkable = 0;
//            // READFILE
//            if (_file.Equals("")){
//                this.map = new char[1,1];
//            }
//            else {
//                string[] baris = File.ReadAllLines(_file);
//                this.sizeY = baris.Length;
//                this.sizeX = baris[0].Length;

//                this.map = new char[baris.Length, baris[0].Length];

//                for (int i = 0; i < baris.Length; i++){
//                    for (int j = 0; j < baris[0].Length; j++){
//                        map[i,j] = baris[i][j];
//                        if (baris[i][j].Equals('T')) this.treasure++;
//                        if (baris[i][j].Equals('T') || baris[i][j].Equals('R') || baris[i][j].Equals('K')) this.walkable++;
//                        if (baris[i][j].Equals('K')) this.start = new Tuple<int, int>(j,i);
//                    }
//                }
//            }
//            // NODE
//            this.nodes = new Dictionary<Tuple<int,int>, Node>();
//            // QUEUE
//            this.queue = new Queue<Node>();
//        }

//        public void printMat(){
//            Console.WriteLine("Size : {0} x {1}", sizeX, sizeY);
//            Console.WriteLine("Walkable : {0}", walkable);
//            Console.WriteLine("Treasure : {0}", treasure);
//            for (int i = 0; i < map.GetLength(0); i++ ){
//                for (int j = 0; j < map.GetLength(1); j++){
//                    Console.Write(map[i,j]);
//                }
//                Console.WriteLine("");
//            }
//        }

//        public void initialize(){
//            // int x = 0;
//            for (int i = 0; i < sizeY; i++){
//                for (int j = 0; j < sizeX; j++){
//                    if (this.map[i,j].Equals('R') || this.map[i,j].Equals('T') || map[i,j].Equals('K')){
//                        Console.WriteLine("N-{0}-{1} : {2}", j, i, map[i,j]);
//                        string _name = String.Format("N{0}{1}", j, i);
//                        Node temp = new Node(_name);
//                        // this.nodes[x].setName(_name);
//                        temp.setCoor(j,i);
//                        if (i-1 >= 0){
//                            if (map[i-1,j].Equals('R') || map[i-1,j].Equals('T') || map[i-1,j].Equals('K')){
//                                temp.setUtara(j,i-1);
//                            }
//                        }
//                        if (i+1 < sizeY){
//                            if (map[i+1,j].Equals('R') || map[i+1,j].Equals('T') || map[i+1,j].Equals('K')){
//                                temp.setSelatan(j,i+1);
//                            }
//                        }
//                        if (j+1 < sizeX){
//                            if (map[i,j+1].Equals('R') || map[i,j+1].Equals('T') || map[i,j+1].Equals('K')){
//                                temp.setTimur(j+1,i);
//                            }
//                        }

//                        if (j-1 >= 0){
//                            if (map[i,j-1].Equals('R') || map[i,j-1].Equals('T') || map[i,j-1].Equals('K')){
//                                temp.setBarat(j-1,i);
//                            }
//                        }

//                        nodes.Add(new Tuple<int,int>(j,i), temp);
//                    }
//                }
//            }
//        }
//        public void printQueue(){
//            Console.Write("[");
//            foreach(Node i in this.queue){
//                Console.Write(i.getName() + " ");
//            }
//            Console.WriteLine("]");
//        }
//        public void HuntBFS(){
//            List<string> path = new List<string>(); 
//            Node curr = nodes[this.start];
//            curr.setVisitNode();

//            curr.printNode();
//            do {
//                path.Add(curr.getName());
//                if (curr.getUtara() != null && !nodes[curr.getUtara()].isVisited()){
//                    nodes[curr.getUtara()].addList(curr);
//                    nodes[curr.getUtara()].setVisitNode();
//                    queue.Enqueue(nodes[curr.getUtara()]);
//                }
//                if (curr.getTimur() != null && !nodes[curr.getTimur()].isVisited()){
//                    nodes[curr.getTimur()].addList(curr);
//                    nodes[curr.getTimur()].setVisitNode();
//                    queue.Enqueue(nodes[curr.getTimur()]);
//                }
//                if (curr.getSelatan() != null && !nodes[curr.getSelatan()].isVisited()){
//                    nodes[curr.getSelatan()].addList(curr);
//                    nodes[curr.getSelatan()].setVisitNode();
//                    queue.Enqueue(nodes[curr.getSelatan()]);
//                }
//                if (curr.getBarat() != null && !nodes[curr.getBarat()].isVisited()){
//                    nodes[curr.getBarat()].addList(curr);
//                    nodes[curr.getBarat()].setVisitNode();
//                    queue.Enqueue(nodes[curr.getBarat()]);
//                }
//                curr = queue.Dequeue();
//                curr.setVisitNode();

//                if (map[curr.getCoor().Item2, curr.getCoor().Item1].Equals('T')){
//                    treasure--;
//                    Console.WriteLine("GET TREASURE");
//                }
//                curr.printNode();
//                printQueue();

//            } while (treasure != 0);
//            Console.Write("[");
//            foreach(string p in path){
//                Console.Write(p + ", ");
//            }
//            Console.WriteLine("]");
//        }

//        public void printNodes(){
//            if (this.nodes == null){
//                Console.WriteLine("NULL");
//            }
//            Console.WriteLine(nodes.Count);
//            for (int i = 0; i < this.nodes.Count; i++){
//                try {
//                    this.nodes.ElementAt(i).Value.printNode();
//                }
//                catch (Exception e){
//                    Console.WriteLine(e.Message);
//                }
//            }

//            nodes[new Tuple<int, int>(1,1)].printNode();
//        }

//        public static void Main(string[] args){
//            Console.Write("Masukkan nama file maze: ");
//            //string fileName = Console.ReadLine();
//            string fileName = "";


//            if (!File.Exists(fileName))
//            {
//                Console.WriteLine("File tidak ditemukan.");
//                return;
//            }            
            
//            BFS test = new BFS(fileName);
//            // test.printMat();
//            test.initialize();
//            test.printMat();

//            // test.printNodes();

//            test.HuntBFS();
//        }
//    }
//}