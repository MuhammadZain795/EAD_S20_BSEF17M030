<?php
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbname = "userdb";
    $conn = mysqli_connect($servername,$username,$password,$dbname);
    if(!$conn){
        die("Connection Failed: ".mysqli_connect_error());
    }
    else{
        $name = $_REQUEST["username"];
        $pass = $_REQUEST["pass"];
        $sql = "Select login from usertable where login='$name' and password='$pass'";
        $result = mysqli_query($conn, $sql);
        $rows = mysqli_num_rows($result);
        if($rows == 1){
            session_start();
            $_SESSION["username"]=$name;
            echo json_encode("confirmed");
        }
        else if($rows == 0){
            echo json_encode("error");
        }
       
    }
?>