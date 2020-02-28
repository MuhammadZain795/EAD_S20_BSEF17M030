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
        $name = $_REQUEST["foldername"];
        $pname = $_REQUEST["parentid"];
        $sql = "Select * from foldertable where foldername='$name' and parentid='$pname'";
        $result = mysqli_query($conn, $sql);
        $rows = mysqli_num_rows($result);
        if($rows == 1){
            echo json_encode("samenNameNotAllowed");
        }
        else if($rows == 0){
            $sql1 = "Insert into foldertable(foldername, parentid) Values ('$name','$pname')";
            $result1 = mysqli_query($conn, $sql1);
            echo json_encode("created");
        }
        echo ("addfolder");
    }
?>