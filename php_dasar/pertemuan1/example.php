<?php
    $nama_lengkap = "Wir";
    $nilai_akhir = 70;
    
    $grade = '';
    if($nilai_akhir >= 85) {
        $grade = 'A';
    } else if($nilai_akhir >= 70) {
        $grade = 'B';
    } else if($nilai_akhir >= 55) {
        $grade = 'C';
    } else {
        $grade = 'D';
    }

    echo "Mahasiswa yang bernama $nama_lengkap mendapatkan nilai $nilai_akhir dengan grade $grade <br> <br>";
    
    //Contoh perulangan
    for ($i=1; $i < 10; $i++) {
        echo "Antrian ke-$i <br> <hr>";
    }

    //Function / Fungsi
    function salam($nama, $waktu) {
        echo "Halo $nama, Selamat $waktu";
        echo '<br>';
    }

    salam('Fakhri', 'Pagi');
    salam('Ahmad', 'Siang');
    salam('Fizi', 'Sore');


    //Function / Fungsi
    function salamDinamis($nama) {
        date_default_timezone_set('Asia/Jakarta');
        $tgl = date('d m Y');
        $waktu = date('Y-m-d H:i:s');
        echo "Halo $nama, Selamat, Hari ini $tgl, $waktu";
        echo '<br>';

    }

    salamDinamis('Wir');



?>