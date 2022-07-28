<h1>Machine Status</h1>
<?
//***Requires extension SQL Anywhere***
//Establish coneccection to SQL and execute querey
$con = sybase_connect("mySQL_Server", "apps", "iamtheapp");
$sqlqry = "select machine, state from PlantProcess.dbo.machineLiveState order by machine";

$qry = sybase_query($sqlqry,$con);

//loop through results
while($row = sybase_fetch_array($qry)){
	$machine[] = $row['machine'];
	$state[] = $row['state'];
}

//Create HTML table for results
echo "<table width=20% align=center borderColor='black' border=1 cellspacing = 0>\n";
echo "<tr>\n";
echo "	<th>Machine<th>\n";
echo "	<th>state<th>\n";
echo "</tr>\n";

//For loop for making table for results, and setting state cell colour depending on value
$i = 0;
for($i=0; $i<=count($machine); $i++){
	echo "<tr>\n";
	echo "	<td>".$machine[$i]."</td>";
	if($state == "Running"){
		echo "	<td bgcolor='green'>".$state[$i]."</td>";
	}
	if($state == "Standby"){
		echo "	<td bgcolor='yellow'>".$state[$i]."</td>";
	}
	if($state == "Starved"){
		echo "	<td bgcolor='red'>".$state[$i]."</td>";
	}
	echo "</tr>\n";
}
echo "</table>";
?>

<script>

//Refresh page every 30 seconds
$(document).ready(function(){
	setInterval(function(){
		refresh_page()
	}, 3000);
});

function refresh_page() {
	window.location.reload();
}

</script>
