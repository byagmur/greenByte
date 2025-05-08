<?php
require_once "Database.php";

$db = new Database();
$conn = $db->conn;

$sicaklik = $_POST['sicaklik'];
$nem = $_POST['nem'];

$sql = "INSERT INTO sensor_verileri (sicaklik, nem) VALUES ('$sicaklik', '$nem')";

if ($conn->query($sql) === TRUE) {
    echo "Veri başarıyla kaydedildi";
} else {
    echo "Hata: " . $conn->error;
}
?>
