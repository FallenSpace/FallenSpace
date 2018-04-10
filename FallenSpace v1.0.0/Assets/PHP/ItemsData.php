<?php
	$servername = "localhost";
	$username =  "root";
	$password = "";
	$dbName = "cool_yt_rpg";
	
	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	
	$sql = "SELECT ID, Name, Type, Cost FROM items";
	$result = mysqli_query($conn ,$sql);
	
	
	if(mysqli_num_rows($result) > 0){
		//show data for each row
		while($row = mysqli_fetch_assoc($result)){
			echo "ID: ".$row['ID'] . " Name: ".$row['Name']. " Type: ".$row['Type']. " Cost: ".$row['Cost'] . "<br>";
		}
	}
	
	
	
	


?>