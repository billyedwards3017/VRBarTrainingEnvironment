<?php

//giving the login credentials of the database for php my admin to the script so it can access the table
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "barlogin";

// Create connection using login info
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection is successful
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
} else {

}

//requests all the information from the table
$sql = "SELECT id, CocktailName, IngredientOne, IngredientTwo, IngredientThree, IceRequired, ShakenRequired, Garnish FROM barlogin.cocktailrecipes";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
   //output data of each row
   $rows = array();
   //iterates through the rows of the table
  while($row = $result->fetch_assoc()) {
	  $rows[] = $row;
  }
  //once each recipe has been extracted, encodes the recipes into json
  echo json_encode($rows);
} else {
	//if there are no recipes in the table
  echo "0 results";
}
//closes the connection
$conn->close();



?>