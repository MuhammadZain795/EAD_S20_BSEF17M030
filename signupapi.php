<?php
    // require 'connection.php';
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbname = "userdb";
    $conn = mysqli_connect($servername,$username,$password,$dbname);
    if(!$conn){
        die("Connection Failed: ".mysqli_connect_error());
    }
    else{
        $name = $_REQUEST["name"];
        $login = $_REQUEST["username"];
        $pass = $_REQUEST["pass"];
        $sql = "Select login from usertable where login='$login'";
        $result = mysqli_query($conn, $sql);
        $rows = mysqli_num_rows($result);
        if($rows == 0){
            $sql1 = "Insert into usertable(login, name, password) Values ('$login','$name','$pass')";
            $result1 = mysqli_query($conn, $sql1);
            echo json_encode("added");
        }
        else if($rows >= 1){
            echo json_encode("error");
        }
    }
?>