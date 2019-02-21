<?php
//Hide all error and warning messages.
error_reporting(0);
//Define variables
$servername = "localhost";
$username = "root";
$password = "smarthome1730";
$dbname = "smarthome_db";
$exitMsg ="";
$myObj = new \stdClass();

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    //die("Connection failed: " . $conn->connect_error);
	$exitMsg = "Connection failed: " . $conn->connect_error;
	$myObj->ExitCode = "1";
	$myObj->SQLResponse = $exitMsg;
    $myJSON = json_encode($myObj);
	echo $myJSON;
	die();
} 

//SQL command
$sql = "SELECT switch1 FROM switches";

//Query SQL command
$result = $conn->query($sql);
if ($result->num_rows > 0) {
	 // output data of each row
    while($row = $result->fetch_assoc()) {
        	$myObj->SwitchState = $row["switch1"];
		//echo "SwitchState: " . $row["switch1"]. "<br>";
	}
	$exitMsg = "Switch state requested successfully";
	$myObj->ExitCode = "0";
	}
 else {
	$exitMsg = "Error request switch state: " . $conn->error;
	$myObj->ExitCode = "1";
}
//Close DB connection
$conn->close();

$myObj->SQLResponse = $exitMsg;

//Encode response to JSON
$myJSON = json_encode($myObj);
echo $myJSON;
?>