<?php
require_once "baglanti.php";

$db = new Database();
$conn = $db->conn;

$result = $conn->query("SELECT * FROM sensor_verileri ORDER BY id DESC");

echo "<h2>Sensor Verileri</h2>
<table border='1'>
<tr><th>ID</th><th>Sıcaklık</th><th>Nem</th><th>Tarih</th></tr>";

while($row = $result->fetch_assoc()) {
    echo "<tr>
            <td>{$row["id"]}</td>
            <td>{$row["sicaklik"]}</td>
            <td>{$row["nem"]}</td>
            <td>{$row["tarih"]}</td>
         </tr>";
}
echo "</table>";
?>
