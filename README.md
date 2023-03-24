# Tubes2_Chashtag
## Tugas Besar 2 IF2211 Strategi Algoritma Semester II Tahun 2022/2023 Pengaplikasian Algoritma BFS dan DFS dalam Menyelesaikan Persoalan Maze Treasure Hunt

<p align="center">
    <img src= https://github.com/rizkyrsyd28/Tubes2_Chashtag/blob/main/image.png
</p>

## Kelompok Chashtag
1. Ilham Akbar			    (13521068)
2. Hobert Anthony Jonatan	(13521079)  
3. Rizky Abdillah Rasyid    (13521109) 

## Struktur Direktori
|---  `src` => berisi *source code* dari program C#<br>
|---  `test` => berisi input file txt untuk maze<br>
|---  `bin` => berisi executable code / hasil build dari program C#<br>
|---  `doc` => berisi file laporan<br>

## Implementasi Algoritma BFS dan DFS dalam Menyelesaikan Persoalan Maze Treasure Hunt

Pada tugas kali ini, program yang akan dibangun adalah sebuah aplikasi GUI sederhana dari Treasure Hunt Solver yang memanfaatkan algoritma Breadth-First Search (BFS) dan Depth-First Search (DFS) untuk mencari rute solusi dari sebuah maze yang berisi harta karun yang perlu ditemukan. Input untuk program ini adalah sebuah file txt yang berisi maze dengan batasan berbentuk segi-empat yang terdiri dari beberapa simbol, yaitu K (Krusty Krab) sebagai titik awal, T (Treasure) sebagai tujuan akhir, R (Grid yang mungkin diakses / sebuah lintasan), dan X (Grid halangan yang tidak dapat diakses).

Program ini memiliki GUI sederhana dengan beberapa fitur, yaitu:

1. Menerima input file maze treasure hunt atau nama file maze tersebut.
2. Memvalidasi file input apakah mengandung simbol yang valid (K, T, R, X) dan menampilkan visualisasi awal dari maze treasure hunt jika valid, atau memunculkan pesan error jika tidak valid.
3. Menggunakan toggle untuk memilih algoritma yang digunakan (BFS atau DFS).
4. Tombol "Search" untuk mengeksekusi pencarian rute solusi dengan algoritma yang dipilih, kemudian menampilkan rute solusi pada visualisasi maze treasure hunt.

## Cara Menjalankan Program
1. Pastikan semua requirement telah diinstal
2. Jalankan Visual Studio Code. 
3. Buka folder src\Chastag\Chastag.
4. Cari file MainWindow.xaml.cs lalu copy pathnya.
5. Buka terminal pada folder src\Chastag\Chastag
6. Jalankan program dengan cara menuliskan dotnet run “path MainWindow.xaml.cs” pada terminal.
7. Setelah tampilan program muncul, klik input file lalu pilih file .txt dari maze.
8. Kemudian, pilih algoritma yang ingin digunakan (BFS/DFS).
9. Centang pada bagian TSP apabila rute solusi yang diperoleh juga harus kembali ke titik awal setelah menemukan segala harta karunnya
10. Tekan Find Treasure ! untuk menemukan semua treasure yang ada.
11. Tekan Visualize untuk menampilkan rute yang mengunjungi semua treasure yang ada




## Requirement dan Instalasi
1. VS Code          (https://code.visualstudio.com/Download)
2. Visual Studio    (https://visualstudio.microsoft.com/downloads/)
3. .NET Framework   (https://dotnet.microsoft.com/en-us/download/dotnet-framework)
4. .NET SDK         (https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.202-windows-x64-installer?journey=vs-code)
