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
        $pid = $_REQUEST["p"];
        $sql = "select * from foldertable where parentid='$pid'";
        $result = mysqli_query($conn, $sql);
        $rows = mysqli_num_rows($result);        
        $data = mysqli_fetch_all($result);
        echo json_encode($data);
     }
?>