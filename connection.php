<?php
    $servername = "localhost";
    $username = "root";
    $password = "1234";
    $dbname = "userdb";
    $conn = mysqli_connect($servername,$username,$password,$dbname);
    if(!$conn){
        die("Connection Failed: ".mysqli_connect_error());
    }
    echo "Connected successfully";
?>