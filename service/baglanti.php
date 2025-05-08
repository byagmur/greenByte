<?php
class Database {
    private $servername = "92.205.171.9";
    private $username = "admin";
    private $password = "Ke3@1.3ySQ1";
    private $dbname = "GreenByte";
    public $conn;

    public function __construct() {
        $this->conn = new mysqli(
            $this->servername, 
            $this->username, 
            $this->password, 
            $this->dbname
        );

        if ($this->conn->connect_error) {
            die("Bağlantı hatası: " . $this->conn->connect_error);
        }
    }

    public function __destruct() {
        $this->conn->close();
    }
}
?>
