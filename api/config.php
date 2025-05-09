<?php
$db_host = $_ENV['DB_HOST'];
$db_user = $_ENV['DB_USER'];
$db_pass = $_ENV['DB_PASS'];
$db_name = $_ENV['DB_NAME'];

function connectDB() {
    global $db_host, $db_user, $db_pass, $db_name;
    
    try {
        $conn = new mysqli($db_host, $db_user, $db_pass, $db_name);
        
        // Bağlantıyı kontrol et
        if ($conn->connect_error) {
            error_log("Veritabanı bağlantı hatası: " . $conn->connect_error);
            die("Veritabanı bağlantı hatası: " . $conn->connect_error);
        }

        $conn->set_charset("utf8");
        
        return $conn;
    } catch (Exception $e) {
        error_log("Veritabanı bağlantı istisnası: " . $e->getMessage());
        die("Veritabanı bağlantı istisnası: " . $e->getMessage());
    }
}

// Güvenli SQL sorguları için giriş temizleme fonksiyonu
function cleanInput($data) {
    $conn = connectDB();
    return $conn->real_escape_string($data);
}

// API yanıtlarını JSON formatında döndüren fonksiyon
function sendResponse($success, $message, $data = null) {
    $response = [
        'success' => $success,
        'message' => $message
    ];
    
    if ($data !== null) {
        $response['data'] = $data;
    }
    
    header('Content-Type: application/json');
    echo json_encode($response);
    exit;
}
?>