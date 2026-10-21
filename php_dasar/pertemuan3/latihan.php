<?php
require 'koneksi.php';

$query = "SELECT * FROM anggota";

$stmt =$pdo->query($query);

$data_anggota = $stmt->fetchAll(PDO::FETCH_ASSOC);

var_dump($data_anggota);







?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Data Anggota Asisten</title>
</head>
<body>
    <h3>Data Anggota</h3>
    <table>
        <tr>
            <th>No</th>
            <th>Nama</th>
            <th>Jurusan</th>
            <th>Kelamin</th>
            <th>Alamat</th>
        </tr>
        <?php foreach($data_anggota as $row) : ?>
        <tr>
            <td><?php $row</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</body>
</html>