let harga = 0;

function pilihPaket(nama, total){

document.getElementById("paket").value = nama;

document.getElementById("harga").value = "Rp " + total.toLocaleString("id-ID");

harga = total;

window.location="#transaksi";

}

document.getElementById("formBayar").addEventListener("submit",function(e){

e.preventDefault();

document.getElementById("popup").style.display="flex";

});

function tutupPopup(){

document.getElementById("popup").style.display="none";

}