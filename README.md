# Tubes2_Chashtag
## Tugas Besar 2 IF2211 Strategi Algoritma Semester II Tahun 2022/2023 Pengaplikasian Algoritma BFS dan DFS dalam Menyelesaikan Persoalan Maze Treasure Hunt

## Daftar Isi
* [Deskripsi Singkat Program](#implementasi-algoritma-bfs-dan-dfs-dalam-menyelesaikan-persoalan-maze-treasure-hunt)
* [Struktur Program](#struktur-program)
* [Requirement Program](#requirement-program)
* [Cara Build Program](#cara-build-program)
* [Cara Menjalankan Program](#cara-menjalankan-program)
* [Authors](#authors)
* [Link Demo Program](#link-demo-program)

<p align="center">
    <img src= https://github.com/rizkyrsyd28/Tubes2_Chashtag/blob/main/image.png
</p>

## Implementasi Algoritma BFS dan DFS dalam Menyelesaikan Persoalan Maze Treasure Hunt

Pada tugas kali ini, program yang akan dibangun adalah sebuah aplikasi GUI sederhana dari Treasure Hunt Solver yang memanfaatkan algoritma Breadth-First Search (BFS) dan Depth-First Search (DFS) untuk mencari rute solusi dari sebuah maze yang berisi harta karun yang perlu ditemukan. Input untuk program ini adalah sebuah file txt yang berisi maze dengan batasan berbentuk segi-empat yang terdiri dari beberapa simbol, yaitu K (Krusty Krab) sebagai titik awal, T (Treasure) sebagai tujuan akhir, R (Grid yang mungkin diakses / sebuah lintasan), dan X (Grid halangan yang tidak dapat diakses).

Program ini memiliki GUI sederhana dengan beberapa fitur, yaitu:

1. Menerima input file maze treasure hunt atau nama file maze tersebut.
2. Memvalidasi file input apakah mengandung simbol yang valid (K, T, R, X) dan menampilkan visualisasi awal dari maze treasure hunt jika valid, atau memunculkan pesan error jika tidak valid.
3. Menggunakan toggle untuk memilih algoritma yang digunakan (BFS atau DFS).
4. Tombol "Search" untuk mengeksekusi pencarian rute solusi dengan algoritma yang dipilih, kemudian menampilkan rute solusi pada visualisasi maze treasure hunt.

## Struktur Program
    .
    │   image.png
    │   README.md
    │
    ├───.vs
    ├───bin
    │   └───Release
    │       └───net6.0-windows
    │               Chashtag.exe
    │
    ├───doc
    ├───src
    │   └───Chashtag
    │       │   Chashtag.sln
    │       │
    │       └───Chashtag
    │           │   App.xaml
    │           │   App.xaml.cs
    │           │   AssemblyInfo.cs
    │           │   Chashtag - Backup.csproj
    │           │   Chashtag.csproj
    │           │   Chashtag.csproj.user
    │           │   MainWindow.xaml
    │           │   MainWindow.xaml.cs
    │           │   
    │           ├───Models
    │           │       BFSAlgo.cs
    │           │       BFSNode.cs
    │           │       DFSAlgo.cs
    │           │       DFSGraph.cs
    │           │
    │           ├───Resource
    │           │       CHashtag.ico
    │           │
    │           ├───ViewModels
    │           │       MainGridCommand.cs
    │           │       MainViewModel.cs
    │           │       SideGridCommand.cs
    │           │       ViewModelBase.cs
    │           │
    │           └───Views
    │               │   MainGrid.xaml
    │               │   MainGrid.xaml.cs
    │               │   SideGrid.xaml
    │               │   SideGrid.xaml.cs
    │               │   ViewBase.xaml
    │               │   ViewBase.xaml.cs
    │               │
    │               └───MainGrids
    │                       CanvasGrid.xaml
    │                       CanvasGrid.xaml.cs
    │                       ResultGrid.xaml
    │                       ResultGrid.xaml.cs
    │
    └───test
            sampel-1.txt
            sampel-2.txt
            sampel-3.txt
            sampel-4.txt
            sampel-5.txt

## Requirement Program
1. Sistem Operasi Windows
2. Visual Studio    (https://visualstudio.microsoft.com/downloads/)
3. .NET Framework   (https://dotnet.microsoft.com/en-us/download/dotnet-framework)
4. .NET SDK         (https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.202-windows-x64-installer?journey=vs-code)

## Cara Build Program
### A. Visual Studio
1. Lakukan `git clone` terhadap repositori ini
2. Buka Solution `CHashtag.sln` pada folder `/src/Chashtag/`
3. Run program dengan menggunakan tombol Run pada Visual Studio 2022
### B. Terminal
1. Lakukan `git clone` terhadap repositori ini
2. Buka Terminal pada folder `Tubes2_Chashtag`
3. Pindahkan direktori ke `cd .\src\Chashtag\`
3. Build dengan project dengan perintah `dotnet publish -c Release`
4. Jika berhasil, executable file akan berapa pada folder `\Tubes2_Chashtag\bin`

## Cara Menjalankan Program
1. Pastikan semua requirement telah terpenuhi
2. Buka folder `\Tubes2_Chashtag\bin\Release\net6.0-windows\`
3. Jalankan file `Chashtag.exe`
4. Setelah tampilan program muncul, klik input file lalu pilih file .txt dari maze.
5. Kemudian, pilih algoritma yang ingin digunakan (BFS/DFS).
6. Centang pada bagian TSP apabila rute solusi yang diperoleh juga harus kembali ke titik awal setelah menemukan segala harta karunnya
7. Tekan Find Treasure ! untuk menemukan semua treasure yang ada.
8. Tekan Visualize untuk menampilkan rute yang mengunjungi semua treasure yang ada
9. Tidak perlu khawatir jika terdapat langkah yang terlewat, karena program ini sudah dilengkapi <i>exception handler</i> yang akan memeberi tahu kesalahan dalam menjalankan program.

## Authors
| Nama                      | NIM      |
|---------------------------|----------|
| Ilham Akbar               | 13521068 |
| Hobert Anthony Jonatan    | 13521079 |
| Rizky Abdillah Rasyid     | 13521109 |

## Link Demo Program
