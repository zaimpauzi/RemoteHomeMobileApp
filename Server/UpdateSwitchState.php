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
$sql = "UPDATE switches SET switch1='".$_GET['state']."'";

//Query SQL command
if ($conn->query($sql) === TRUE) {
	$exitMsg = "Record updated successfully";
	$myObj->ExitCode = "0";
} else {
	$exitMsg = "Error updating record: " . $conn->error;
	$myObj->ExitCode = "1";
}
//Close DB connection
$conn->close();

$myObj->SQLResponse = $exitMsg;

//Encode response to JSON
$myJSON = json_encode($myObj);
echo $myJSON;
?>