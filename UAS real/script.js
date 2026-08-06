/* ===================================================
   HALAMAN PRODUK
=================================================== */

// Tombol sewa
function sewa(nama, harga) {
    window.location.href =
        `transaksi.html?produk=${encodeURIComponent(nama)}&harga=${harga}`;
}

// Pencarian produk
const search = document.getElementById("search");

if (search) {
    search.addEventListener("keyup", function () {

        let filter = this.value.toUpperCase();

        let produk = document.querySelectorAll(".produk");

        produk.forEach(function (card) {

            let nama = card.querySelector("h3").textContent.toUpperCase();

            if (nama.indexOf(filter) > -1) {
                card.style.display = "block";
            } else {
                card.style.display = "none";
            }

        });

    });
}

/* ===================================================
   HALAMAN TRANSAKSI
=================================================== */

const params = new URLSearchParams(window.location.search);

const produk = params.get("produk");
const harga = params.get("harga");

const inputProduk = document.getElementById("produk");
const inputHarga = document.getElementById("harga");

if (inputProduk && inputHarga) {

    inputProduk.value = produk || "";

    inputHarga.value = harga
        ? "Rp " + Number(harga).toLocaleString("id-ID")
        : "";

}

function hitungTotal() {

    const nama = document.getElementById("nama").value;

    const hp = document.getElementById("hp").value;

    const hari = parseInt(document.getElementById("hari").value);

    const tanggal = document.getElementById("tgl").value;

    const total = Number(harga) * hari;

    document.getElementById("hasil").innerHTML = `

        <b>Nama</b><br>
        ${nama}<br><br>

        <b>No HP</b><br>
        ${hp}<br><br>

        <b>Produk</b><br>
        ${produk}<br><br>

        <b>Harga / Hari</b><br>
        Rp ${Number(harga).toLocaleString("id-ID")}<br><br>

        <b>Lama Sewa</b><br>
        ${hari} Hari<br><br>

        <b>Tanggal Sewa</b><br>
        ${tanggal}<br><br>

        <hr>

        <h2>Total</h2>

        <h1 style="color:green;">
            Rp ${Number(total).toLocaleString("id-ID")}
        </h1>

    `;

    alert("Transaksi berhasil dihitung!");

}

/* ===================================================
   HALAMAN BERANDA
=================================================== */

window.addEventListener("scroll", function () {

    const header = document.querySelector("header");

    if (!header) return;

    if (window.scrollY > 50) {

        header.style.background = "#005f99";
        header.style.boxShadow = "0 5px 15px rgba(0,0,0,.2)";

    } else {

        header.style.background = "#0077b6";
        header.style.boxShadow = "none";

    }

});